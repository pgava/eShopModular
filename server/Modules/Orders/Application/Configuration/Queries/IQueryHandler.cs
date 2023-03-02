using eShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace eShopModular.Modules.Orders.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}