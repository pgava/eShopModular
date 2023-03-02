using eShopModular.Modules.Products.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Products.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}