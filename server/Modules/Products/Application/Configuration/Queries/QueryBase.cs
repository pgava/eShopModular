using eShopModular.Modules.Products.Application.Contracts;

namespace eShopModular.Modules.Products.Application.Configuration.Queries;

public abstract class QueryBase<TResult> : IQuery<TResult>
{
    public Guid Id { get; }

    protected QueryBase()
    {
        Id = Guid.NewGuid();
    }
}