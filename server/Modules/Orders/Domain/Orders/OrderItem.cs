#nullable disable
using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Orders;

public class OrderItem : Entity
{
    internal OrderItemId Id { get; set; }

    internal OrderId OrderId { get; private set; }

    private Guid _productId;

    private int _quantity;

    private decimal _price;

    internal static OrderItem CreateNew(OrderId orderId, Guid productId, int quantity, decimal price)
    {
        return new OrderItem(new OrderItemId(Guid.NewGuid()), orderId, productId, quantity, price);
    }

    private OrderItem()
    {
    }

    private OrderItem(OrderItemId id, OrderId orderId, Guid productId, int quantity, decimal price)
    {
        Id = id;
        OrderId = orderId;
        _productId = productId;
        _quantity = quantity;
        _price = price;
    }
}
#nullable enable