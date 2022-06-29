namespace eShopCmc.Domain.Products;

public class Product
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
    public Decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
