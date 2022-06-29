using Serilog;
using Serilog.Formatting.Compact;

namespace eShopCmc.Api;

internal static class CreateLogger
{
    public static Serilog.ILogger GetLogger()
    {
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(new CompactJsonFormatter(), "logs/logs.txt")
            .WriteTo.Seq("http://eshop.seq:5341")
            .CreateLogger();
        
        logger.Information("Logger configured");

        return logger;
    }
}