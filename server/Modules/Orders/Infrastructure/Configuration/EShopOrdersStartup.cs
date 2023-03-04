using Autofac;
using EShopModular.Common.Application;
using EShopModular.Modules.Orders.Infrastructure.Configuration.DataAccess;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Logging;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Mediation;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration
{
    public class EShopOrdersStartup
    {
        private static IContainer? _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "EShopOrders");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger);
        }

        public static void Stop()
        {
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "EShopOrders")));

            var loggerFactory = new SerilogLoggerFactory(logger);

            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new MediatorModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            EShopOrdersCompositionRoot.SetContainer(_container);
        }
    }
}