using eShopCmc.Application.Contracts;
using MediatR;

namespace eShopCmc.Infrastructure;

public class EShopCmcModule : IEShopCmcModule
{
    private readonly IMediator _mediator;

    public EShopCmcModule(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task ExecuteCommandAsync(ICommand command)
    {
        await new CommandsExecutor(_mediator).Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        return await _mediator.Send(query);
    }
}