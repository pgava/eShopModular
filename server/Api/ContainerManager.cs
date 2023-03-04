using Autofac;
using EShopModular.Common.Application;
using EShopModular.Modules.Orders.Infrastructure.Configuration;
using EShopModular.Modules.Products.Infrastructure.Configuration;
using ILogger = Serilog.ILogger;

namespace EShopModular.Api;

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