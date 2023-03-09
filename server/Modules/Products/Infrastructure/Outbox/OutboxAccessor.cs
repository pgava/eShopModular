using EShopModular.Common.Application.Outbox;

namespace EShopModular.Modules.Products.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly EShopProductsContext _eShopProductsContext;

    internal OutboxAccessor(EShopProductsContext eShopProductsContext)
    {
        _eShopProductsContext = eShopProductsContext;
    }

    public void Add(OutboxMessage message)
    {
        _eShopProductsContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
    }
}