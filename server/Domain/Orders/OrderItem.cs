using eShopCmc.Domain.Products;

namespace eShopCmc.Domain.Orders;

public class OrderItem
{
    public OrderItem(OrderItemId id, OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
    
    public OrderItemId Id { get; set; }
    public OrderId OrderId { get; set; }
    public ProductId ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}