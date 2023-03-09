using Dapper;
using EShopModular.Common.Infrastructure;
using EShopModular.Common.Infrastructure.Serialization;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using EShopModular.Modules.Products.Application.Contracts;
using Newtonsoft.Json;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing.InternalCommands;

public class CommandsScheduler : ICommandsScheduler
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task EnqueueAsync(ICommand command)
    {
        var connection = this._sqlConnectionFactory.GetOpenConnection();

        const string sqlInsert = "INSERT INTO [order].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                 "(@Id, @EnqueueDate, @Type, @Data)";

        await connection.ExecuteAsync(sqlInsert, new
        {
            command.Id,
            EnqueueDate = DateTime.UtcNow,
            Type = command.GetType().FullName,
            Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            })
        });
    }
}