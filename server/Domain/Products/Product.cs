namespace eShopCmc.Domain.Products;

public class Product
{
    public ProductId Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
