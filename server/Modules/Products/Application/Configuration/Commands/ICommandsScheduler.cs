using EShopModular.Modules.Products.Application.Contracts;

namespace EShopModular.Modules.Products.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);
}