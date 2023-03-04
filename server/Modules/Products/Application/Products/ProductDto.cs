namespace EShopModular.Modules.Products.Application.Products;

public class ProductDto
{
    public ProductDto(Guid id, string name, decimal price, string imageUrl, string description)
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
