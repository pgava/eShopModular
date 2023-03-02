using Autofac;
using eShopModular.Modules.Products.Application.Contracts;
using eShopModular.Modules.Products.Infrastructure.Configuration;
using eShopModular.Modules.Products.Infrastructure.Configuration.Processing;
using MediatR;

namespace eShopModular.Modules.Products.Infrastructure;

public class EShopProductsModule : IEShopProductsModule
{
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = EShopProductsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}