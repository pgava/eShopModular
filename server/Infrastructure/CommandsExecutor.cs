using Autofac;
using eShopModular.Application.Contracts;
using eShopModular.Infrastructure.Configuration;
using MediatR;

namespace eShopModular.Infrastructure;

public static class CommandsExecutor
{
    public static async Task Execute(ICommand command)
    {
        using (var scope = EShopCmcCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            await mediator.Send(command);
        }
    }
}