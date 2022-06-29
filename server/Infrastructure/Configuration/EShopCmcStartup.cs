using Autofac;
using eShopCmc.Infrastructure.Configuration.DataAccess;
using eShopCmc.Infrastructure.Configuration.Logging;
using eShopCmc.Infrastructure.Configuration.Mediation;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace eShopCmc.Infrastructure.Configuration
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