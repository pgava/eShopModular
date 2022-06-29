using Autofac;
using eShopCmc.Application.Contracts;
using eShopCmc.Infrastructure.Configuration;
using MediatR;

namespace eShopCmc.Infrastructure;

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