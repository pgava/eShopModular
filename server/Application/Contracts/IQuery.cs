using MediatR;

namespace eShopModular.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}