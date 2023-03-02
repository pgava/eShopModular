using MediatR;

namespace eShopModular.Modules.Orders.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}