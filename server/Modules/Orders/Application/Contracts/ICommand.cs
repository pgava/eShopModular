using MediatR;

namespace EShopModular.Modules.Orders.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}