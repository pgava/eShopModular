using eShopModular.Modules.Products.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Products.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
