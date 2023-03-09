using Dapper;
using EShopModular.Common.Application.Events;
using EShopModular.Common.Infrastructure;
using EShopModular.Common.Infrastructure.DomainEventsDispatching;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using MediatR;
using Newtonsoft.Json;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing.Outbox
{
    internal class ProcessOutboxCommandHandler : IRequestHandler<ProcessOutboxCommand>, ICommandHandler
    {
        private readonly IMediator _mediator;

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly IDomainNotificationsMapper _domainNotificationsMapper;

        public ProcessOutboxCommandHandler(
            IMediator mediator,
            ISqlConnectionFactory sqlConnectionFactory,
            IDomainNotificationsMapper domainNotificationsMapper)
        {
            _mediator = mediator;
            _sqlConnectionFactory = sqlConnectionFactory;
            _domainNotificationsMapper = domainNotificationsMapper;
        }

        public async Task Handle(ProcessOutboxCommand command, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
                         $"[OutboxMessage].[Id] AS [{nameof(OutboxMessageDto.Id)}], " +
                         $"[OutboxMessage].[Type] AS [{nameof(OutboxMessageDto.Type)}], " +
                         $"[OutboxMessage].[Data] AS [{nameof(OutboxMessageDto.Data)}] " +
                         "FROM [order].[OutboxMessages] AS [OutboxMessage] " +
                         "WHERE [OutboxMessage].[ProcessedDate] IS NULL " +
                         "ORDER BY [OutboxMessage].[OccurredOn]";

            var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
            var messagesList = messages.AsList();

            const string sqlUpdateProcessedDate = "UPDATE [order].[OutboxMessages] " +
                                                  "SET [ProcessedDate] = @Date " +
                                                  "WHERE [Id] = @Id";
            if (messagesList.Count > 0)
            {
                foreach (var message in messagesList)
                {
                    var type = _domainNotificationsMapper.GetType(message.Type);
                    var @event = JsonConvert.DeserializeObject(message.Data, type) as IDomainEventNotification;

                    if (@event != null)
                    {
                        using (LogContext.Push(new OutboxMessageContextEnricher(@event)))
                        {
                            await this._mediator.Publish((object)@event, cancellationToken);

                            await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                            {
                                Date = DateTime.UtcNow,
                                message.Id
                            });
                        }
                    }
                }
            }
        }

        private class OutboxMessageContextEnricher : ILogEventEnricher
        {
            private readonly IDomainEventNotification _notification;

            public OutboxMessageContextEnricher(IDomainEventNotification notification)
            {
                _notification = notification;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"OutboxMessage:{_notification.Id.ToString()}")));
            }
        }
    }
}