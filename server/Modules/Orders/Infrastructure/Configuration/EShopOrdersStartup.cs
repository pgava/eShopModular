using Autofac;
using EShopModular.Common.Application;
using EShopModular.Common.Infrastructure;
using EShopModular.Common.Infrastructure.EventBus;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Orders;
using EShopModular.Modules.Orders.Infrastructure.Configuration.DataAccess;
using EShopModular.Modules.Orders.Infrastructure.Configuration.EventsBus;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Logging;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Mediation;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing.Outbox;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Quartz;
using MediatR;
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
            ILogger logger,
            IEventsBus? eventsBus)
        {
            var moduleLogger = logger.ForContext("Module", "EShopOrders");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger);
            EventsBusStartup.Initialize(moduleLogger);
        }

        public static void Stop()
        {
            QuartzStartup.StopQuartz();
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            IEventsBus? eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "EShopOrders")));

            var loggerFactory = new SerilogLoggerFactory(logger);

            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));

            var domainNotificationsMap = new BiDictionary<string, Type>();
            domainNotificationsMap.Add("OrderCreatedNotification", typeof(OrderCreatedNotification));

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            var handler = _container.Resolve<IRequestHandler<ProcessOutboxCommand>>();

            EShopOrdersCompositionRoot.SetContainer(_container);
        }
    }
}