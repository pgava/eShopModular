using eShopCmc.Application.Contracts;
using MediatR;

namespace eShopCmc.Infrastructure;

public class CommandsExecutor
{
    private readonly IMediator _mediator;

    public CommandsExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }
    internal async Task Execute(ICommand command)
    {
        await _mediator.Send(command);
    }

    // internal async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    // {
    //     return await _mediator.Send(command);
    // }
}