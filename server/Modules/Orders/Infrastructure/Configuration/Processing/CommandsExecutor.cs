using Autofac;
using eShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

public static class CommandsExecutor
{
    public static async Task Execute(ICommand command)
    {
        using (var scope = EShopOrdersCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            await mediator.Send(command);
        }
    }
}