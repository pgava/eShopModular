using eShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Orders.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
