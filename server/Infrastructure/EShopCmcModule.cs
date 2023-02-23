using Autofac;
using eShopModular.Application.Contracts;
using eShopModular.Infrastructure.Configuration;
using MediatR;

namespace eShopModular.Infrastructure;

public class EShopCmcModule : IEShopCmcModule
{
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = EShopCmcCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}