using eShopCmc.Domain.Products;

namespace eShopCmc.Domain.Orders;

public class OrderItem
{
    public OrderItemId Id { get; set; }
    public OrderId OrderId { get; set; }
    public ProductId ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}