using MediatR;

namespace eShopModular.Modules.Products.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}