using EShopModular.Modules.Orders.Application.Contracts;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}