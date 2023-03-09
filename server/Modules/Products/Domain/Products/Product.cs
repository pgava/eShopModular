using EShopModular.Common.Domain;

namespace EShopModular.Modules.Products.Domain.Products;

public class Product : Entity, IAggregateRoot
{
    public Product(ProductId id, string name, string description, string imageUrl, decimal price)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
    }

    public ProductId Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}
