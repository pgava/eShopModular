using MediatR;

namespace eShopModular.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}