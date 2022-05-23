using eShopCmc.Application.Contracts;

namespace eShopCmc.Application.Configuration.Queries;

public abstract class QueryBase<TResult> : IQuery<TResult>
{
    public Guid Id { get; }

    protected QueryBase()
    {
        Id = Guid.NewGuid();
    }
}