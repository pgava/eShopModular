using Autofac;
using eShopModular.Api.Configuration.ExecutionContext;
using eShopModular.Application;
using eShopModular.Common.Application;
using eShopModular.Infrastructure.Configuration;
using ILogger = Serilog.ILogger;

namespace eShopModular.Api;

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