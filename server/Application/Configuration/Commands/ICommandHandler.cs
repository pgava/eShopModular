using eShopModular.Application.Contracts;
using MediatR;

namespace eShopModular.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
