using Autofac;
using EShopModular.Common.Application;
using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Infrastructure.Configuration.DataAccess;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Logging;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Mediation;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing.Outbox;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Quartz;
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

            QuartzStartup.Initialize(moduleLogger);
        }

        public static void Stop()
        {
            QuartzStartup.StopQuartz();
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
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();

            // Add domain notifications here
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            EShopOrdersCompositionRoot.SetContainer(_container);
        }
    }
}