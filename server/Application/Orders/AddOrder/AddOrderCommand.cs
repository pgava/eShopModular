using eShopCmc.Application.Contracts;
using eShopCmc.Application.Products;

namespace eShopCmc.Application.Orders.AddOrder;

public class AddOrderCommand : CommandBase
{
    public AddOrderCommand(string currency, decimal exchangeRate, decimal shippingCost, decimal totalCost,  List<ShoppingCart> products)
    {
        Currency = currency;
        ExchangeRate = exchangeRate;
        ShippingCost = shippingCost;
        TotalCost = totalCost;
        Products = products;
    }

    public decimal ShippingCost { get; set; }
    public decimal TotalCost { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
    public List<ShoppingCart> Products { get; set; }
}
public class ShoppingCart
{
    public ShoppingCart(int quantity, ProductViewModel product)
    {
        Quantity = quantity;
        Product = product;
    }

    public int Quantity { get; set; }
    public ProductViewModel Product { get; set; }
}