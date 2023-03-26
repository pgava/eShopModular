using System.Data;
using System.Data.SqlClient;
using Dapper;
using EShopModular.Common.Domain;
using EShopModular.Common.IntegrationTests;
using EShopModular.Common.IntegrationTests.Probing;
using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Domain.SharedKernel;
using EShopModular.Modules.Orders.Infrastructure;
using EShopModular.Modules.Orders.Infrastructure.Configuration;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Serilog;

namespace EShopModular.Modules.Orders.IntegrationTests.SeedWork;

public class TestBase : IDisposable
{
    protected string ConnectionString { get; private set; }

    protected ILogger Logger { get; private set; }

    protected IEShopOrdersModule EShopOrdersModule { get; private set; }
    
    protected ExecutionContextMock ExecutionContext { get; private set; }

    
    public TestBase()
    {
        const string connectionStringEnvironmentVariable =
            "ASPNETCORE_EShop_IntegrationTests_ConnectionString";
        ConnectionString = EnvironmentVariablesProvider.GetVariable(connectionStringEnvironmentVariable);
        if (ConnectionString == null)
        {
            throw new ApplicationException(
                $"Define connection string to integration tests database using environment variable: {connectionStringEnvironmentVariable}");
        }

        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            ClearDatabase(sqlConnection).GetAwaiter().GetResult();
        }

        ExecutionContext = new ExecutionContextMock(Guid.NewGuid());
        Logger = Substitute.For<ILogger>();
        
        EShopOrdersStartup.Initialize(
            ConnectionString,
            ExecutionContext,
            Logger,
            null);

        EShopOrdersModule = new EShopOrdersModule();
    }

    protected async Task ExecuteScript(string scriptPath)
    {
        var sql = await File.ReadAllTextAsync(scriptPath);

        await using var sqlConnection = new SqlConnection(ConnectionString);
        await sqlConnection.ExecuteScalarAsync(sql);
    }

    protected async Task<T> GetLastOutboxMessage<T>()
        where T : class, INotification
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var messages = await OutboxMessagesHelper.GetOutboxMessages(connection);

            return OutboxMessagesHelper.Deserialize<T>(messages.Last());
        }
    }

    public static async Task AssertBrokenRule<TRule>(Func<Task> testDelegate)
        where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        
        var businessRuleValidationException = await Assert.ThrowsAsync<BusinessRuleValidationException>(testDelegate);
        
        businessRuleValidationException.BrokenRule.Should().BeOfType<TRule>(message);
    }

    protected static async Task AssertEventually(IProbe probe, int timeout)
    {
        await new Poller(timeout).CheckAsync(probe);
    }

    private static async Task ClearDatabase(IDbConnection connection)
    {
        const string sql = "DELETE FROM [order].[InboxMessages] " +
                           "DELETE FROM [order].[InternalCommands] " +
                           "DELETE FROM [order].[OutboxMessages] " +
                           "DELETE FROM [order].[OrderItems] " +
                           "DELETE FROM [order].[Orders] ";

        await connection.ExecuteScalarAsync(sql);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            EShopOrdersStartup.Stop();
            SystemClock.Reset();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}