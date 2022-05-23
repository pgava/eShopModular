using eShopCmc.Application.Contracts;
using eShopCmc.Application.Products;

namespace eShopCmc.Application.Orders.AddOrder;

public class AddOrderCommand : CommandBase
{
    public decimal ShippingCost { get; set; }
    public decimal TotalCost { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
    public List<ShoppingCart> Products { get; set; }
}
public class ShoppingCart
{
    public int Quantity { get; set; }
    public ProductViewModel Product { get; set; }
}