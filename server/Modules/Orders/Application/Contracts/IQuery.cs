using MediatR;

namespace EShopModular.Modules.Orders.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}