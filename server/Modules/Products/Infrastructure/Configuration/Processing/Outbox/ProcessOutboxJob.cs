using Quartz;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing.Outbox;

[DisallowConcurrentExecution]
public class ProcessOutboxJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessOutboxCommand());
    }
}