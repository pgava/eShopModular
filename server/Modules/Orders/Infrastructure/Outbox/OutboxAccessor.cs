using EShopModular.Common.Application.Outbox;

namespace EShopModular.Modules.Orders.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly EShopOrdersContext _eShopOrdersContext;

    internal OutboxAccessor(EShopOrdersContext eShopOrdersContext)
    {
        _eShopOrdersContext = eShopOrdersContext;
    }

    public void Add(OutboxMessage message)
    {
        _eShopOrdersContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
    }
}