using Autofac;
using eShopModular.Common.Application;
using eShopModular.Modules.Orders.Infrastructure.Configuration;
using eShopModular.Modules.Products.Infrastructure.Configuration;
using ILogger = Serilog.ILogger;

namespace eShopModular.Api;

public static class ContainerManager
{
    private const string EShopCmcConnectionString = "ConnectionStrings:eShopDb";

    public static void InitializeModules(ILifetimeScope container, ILogger logger, IConfiguration configuration)
    {
        var executionContextAccessor = container.Resolve<IExecutionContextAccessor>();
        
        EShopOrdersStartup.Initialize(
            configuration[EShopCmcConnectionString],
            executionContextAccessor,
            logger);
        
        EShopProductsStartup.Initialize(
            configuration[EShopCmcConnectionString],
            executionContextAccessor,
            logger);

    }
}