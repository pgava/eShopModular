namespace eShopCmc.Domain.Orders;

public class Order
{
    public OrderId Id { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalCost { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
    public DateTime CreateDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}