using EShopModular.Modules.Products.Application.Contracts;
using MediatR;

namespace EShopModular.Modules.Products.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}
