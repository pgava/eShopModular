﻿using Dapper;
using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using MediatR;
using Newtonsoft.Json;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing.Inbox;

internal class ProcessInboxCommandHandler : IRequestHandler<ProcessInboxCommand>, ICommandHandler
{
    private readonly IMediator _mediator;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ProcessInboxCommandHandler(IMediator mediator, ISqlConnectionFactory sqlConnectionFactory)
    {
        _mediator = mediator;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task Handle(ProcessInboxCommand command, CancellationToken cancellationToken)
    {
        var connection = this._sqlConnectionFactory.GetOpenConnection();
        string sql = "SELECT " +
                     $"[InboxMessage].[Id] AS [{nameof(InboxMessageDto.Id)}], " +
                     $"[InboxMessage].[Type] AS [{nameof(InboxMessageDto.Type)}], " +
                     $"[InboxMessage].[Data] AS [{nameof(InboxMessageDto.Data)}] " +
                     "FROM [order].[InboxMessages] AS [InboxMessage] " +
                     "WHERE [InboxMessage].[ProcessedDate] IS NULL " +
                     "ORDER BY [InboxMessage].[OccurredOn]";

        var messages = await connection.QueryAsync<InboxMessageDto>(sql);

        const string sqlUpdateProcessedDate = "UPDATE [order].[InboxMessages] " +
                                              "SET [ProcessedDate] = @Date " +
                                              "WHERE [Id] = @Id";

        foreach (var message in messages)
        {
            var messageAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly =>
                {
                    var value = assembly.GetName().Name;
                    return value != null && message.Type.Contains(value);
                });

            if (messageAssembly != null)
            {
                Type? type = messageAssembly.GetType(message.Type);
                if (type != null)
                {
                    var request = JsonConvert.DeserializeObject(message.Data, type);

                    try
                    {
                        await _mediator.Publish((INotification)request!, cancellationToken);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            await connection.ExecuteScalarAsync(sqlUpdateProcessedDate, new
            {
                Date = DateTime.UtcNow,
                message.Id
            });
        }
    }
}