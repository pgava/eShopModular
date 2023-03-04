using System.Threading.Tasks;
using Autofac;
using EShopModular.Modules.Products.Application.Contracts;
using EShopModular.Modules.Products.Infrastructure.Configuration;
using EShopModular.Modules.Products.Infrastructure.Configuration.Processing;
using MediatR;

namespace EShopModular.Modules.Products.Infrastructure;

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