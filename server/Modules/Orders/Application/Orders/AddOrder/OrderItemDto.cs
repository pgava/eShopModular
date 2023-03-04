namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

public class OrderItemDto
{
    public OrderItemDto(int quantity, ProductOrderDto product)
    {
        Quantity = quantity;
        Product = product;
    }

    public int Quantity { get; set; }

    public ProductOrderDto Product { get; set; }
}