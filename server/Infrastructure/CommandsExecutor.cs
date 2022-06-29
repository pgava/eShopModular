using Autofac;
using eShopCmc.Application.Contracts;
using eShopCmc.Infrastructure.Configuration;
using MediatR;

namespace eShopCmc.Infrastructure;

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