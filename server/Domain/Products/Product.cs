namespace eShopCmc.Domain.Products;

public class Product
{
    public Product()
    {
        Name = string.Empty;
        ImageUrl = string.Empty;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
