using eShopCmc.Application.Contracts;
using MediatR;

namespace eShopCmc.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
