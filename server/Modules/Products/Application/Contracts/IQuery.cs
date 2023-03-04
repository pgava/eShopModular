using MediatR;

namespace EShopModular.Modules.Products.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}