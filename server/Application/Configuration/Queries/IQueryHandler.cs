using eShopCmc.Application.Contracts;
using MediatR;

namespace eShopCmc.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}