using System.Threading.Tasks;
using Autofac;
using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

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

    internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    {
        using (var scope = EShopOrdersCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            return await mediator.Send(command);
        }
    }
}