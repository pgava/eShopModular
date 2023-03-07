using EShopModular.Modules.Orders.Application.Contracts;

namespace EShopModular.Modules.Orders.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);
}