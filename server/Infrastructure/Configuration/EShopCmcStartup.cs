using Autofac;
using eShopModular.Application;
using eShopModular.Common.Application;
using eShopModular.Infrastructure.Configuration.DataAccess;
using eShopModular.Infrastructure.Configuration.Logging;
using eShopModular.Infrastructure.Configuration.Mediation;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace eShopModular.Infrastructure.Configuration
{
    public class EShopCmcStartup
    {
        private static IContainer? _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger)
        {
            var moduleLogger = logger.ForContext("Module", "EShopCmc");

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

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "EShopCmc")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new MediatorModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            EShopCmcCompositionRoot.SetContainer(_container);
        }
    }
}