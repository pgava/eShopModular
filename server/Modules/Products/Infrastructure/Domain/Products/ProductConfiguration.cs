using eShopModular.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopModular.Modules.Products.Infrastructure.Domain.Products;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "product");

        builder.HasKey(x => x.Id);
    }
}