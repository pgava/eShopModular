using Autofac;
using eShopModular.Modules.Products.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Products.Infrastructure.Configuration.Processing;

public static class CommandsExecutor
{
    public static async Task Execute(ICommand command)
    {
        using (var scope = EShopProductsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();
            await mediator.Send(command);
        }
    }
}