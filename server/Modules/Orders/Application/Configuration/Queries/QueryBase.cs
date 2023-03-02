using eShopModular.Modules.Orders.Application.Contracts;

namespace eShopModular.Modules.Orders.Application.Configuration.Queries;

public abstract class QueryBase<TResult> : IQuery<TResult>
{
    public Guid Id { get; }

    protected QueryBase()
    {
        Id = Guid.NewGuid();
    }
}