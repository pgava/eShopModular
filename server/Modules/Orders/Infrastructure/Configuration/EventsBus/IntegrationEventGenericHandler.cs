using Autofac;
using Dapper;
using EShopModular.Common.Infrastructure;
using EShopModular.Common.Infrastructure.EventBus;
using EShopModular.Common.Infrastructure.Serialization;
using Newtonsoft.Json;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.EventsBus;

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    public async Task Handle(T @event)
    {
        using (var scope = EShopOrdersCompositionRoot.BeginLifetimeScope())
        {
            using (var connection = scope.Resolve<ISqlConnectionFactory>().GetOpenConnection())
            {
                var fullName = @event.GetType().FullName;
                if (fullName != null)
                {
                    string type = fullName;
                    var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                    {
                        ContractResolver = new AllPropertiesContractResolver()
                    });

                    var sql = "INSERT INTO [order].[InboxMessages] (Id, OccurredOn, Type, Data) " +
                              "VALUES (@Id, @OccurredOn, @Type, @Data)";

                    await connection.ExecuteScalarAsync(sql, new
                    {
                        @event.Id,
                        @event.OccurredOn,
                        type,
                        data
                    });
                }
            }
        }
    }
}