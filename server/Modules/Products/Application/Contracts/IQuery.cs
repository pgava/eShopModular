using MediatR;

namespace eShopModular.Modules.Products.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}