namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

public class ProductOrderDto
{
    public ProductOrderDto(Guid id, string name, decimal price, string imageUrl, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        Description = description;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public string Description { get; set; }
}
