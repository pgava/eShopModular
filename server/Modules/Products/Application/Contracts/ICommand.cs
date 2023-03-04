using MediatR;

namespace EShopModular.Modules.Products.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}