using eShopModular.Modules.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopModular.Modules.Orders.Infrastructure.Domain.Orders;

internal class ItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("Items", "order");

        builder.HasKey(x => x.Id);
    }
}