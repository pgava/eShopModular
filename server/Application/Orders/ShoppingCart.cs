namespace eShopCmc.Application.Orders;

public class ShoppingCart
{
    public ShoppingCart(Product product)
    {
        Product = product;
    }

    public int Quantity { get; set; }
    public Product Product { get; set; }
}