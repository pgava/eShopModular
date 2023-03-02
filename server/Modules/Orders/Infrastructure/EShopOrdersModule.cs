using Autofac;
using eShopModular.Modules.Orders.Application.Contracts;
using eShopModular.Modules.Orders.Infrastructure.Configuration;
using eShopModular.Modules.Orders.Infrastructure.Configuration.Processing;
using MediatR;

namespace eShopModular.Modules.Orders.Infrastructure;

public class EShopOrdersModule : IEShopOrdersModule
{
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = EShopOrdersCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}