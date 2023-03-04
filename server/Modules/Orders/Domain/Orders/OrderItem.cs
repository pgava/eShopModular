namespace EShopModular.Modules.Orders.Domain.Orders;

public class OrderItem
{
    public OrderItem(OrderItemId id, OrderId orderId, Guid productId, int quantity, decimal price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public OrderItemId Id { get; set; }

    public OrderId OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}