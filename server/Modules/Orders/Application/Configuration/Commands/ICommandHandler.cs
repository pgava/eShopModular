using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
