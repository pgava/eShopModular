using Autofac;
using eShopCmc.Api.Configuration.ExecutionContext;
using eShopCmc.Infrastructure.Configuration;
using ILogger = Serilog.ILogger;

namespace eShopCmc.Api;

public static class ContainerManager
{
    private const string EShopCmcConnectionString = "ConnectionStrings:eShopDb";

    public static void InitializeModules(ILifetimeScope container, ILogger logger, IConfiguration configuration)
    {
        var executionContextAccessor = container.Resolve<IExecutionContextAccessor>();
        
        EShopCmcStartup.Initialize(
            configuration[EShopCmcConnectionString],
            executionContextAccessor,
            logger);
    }
}