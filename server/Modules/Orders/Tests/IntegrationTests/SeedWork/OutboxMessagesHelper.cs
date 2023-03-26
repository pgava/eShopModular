using System.Data;
using System.Reflection;
using Dapper;
using EShopModular.Modules.Orders.Application.Orders;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing.Outbox;
using MediatR;
using Newtonsoft.Json;

namespace EShopModular.Modules.Orders.IntegrationTests.SeedWork;

public class OutboxMessagesHelper
{
    public static async Task<List<OutboxMessageDto>> GetOutboxMessages(IDbConnection connection)
    {
        const string sql = "SELECT " +
                           "[OutboxMessage].[Id], " +
                           "[OutboxMessage].[Type], " +
                           "[OutboxMessage].[Data] " +
                           "FROM [meetings].[OutboxMessages] AS [OutboxMessage] " +
                           "ORDER BY [OutboxMessage].[OccurredOn]";

        var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
        return messages.AsList();
    }

    public static T Deserialize<T>(OutboxMessageDto message)
        where T : class, INotification
    {
        Type type = Assembly.GetAssembly(typeof(OrderCreatedNotification))?.GetType(message.Type) ?? throw new InvalidOperationException();
        return JsonConvert.DeserializeObject(message.Data, type) as T ?? throw new InvalidOperationException();
    }
}