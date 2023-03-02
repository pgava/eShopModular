using MediatR;

namespace eShopModular.Modules.Orders.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}