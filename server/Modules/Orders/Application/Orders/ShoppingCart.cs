namespace eShopModular.Modules.Orders.Application.Orders;

public class ShoppingCart2
{
    public ShoppingCart2(Product product)
    {
        Product = product;
    }

    public int Quantity { get; set; }
    public Product Product { get; set; }
}