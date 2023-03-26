using EShopModular.Modules.Orders.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopModular.Modules.Orders.Infrastructure.Domain.Orders;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "order");

        builder.HasKey(x => x.Id);

        builder.Property<decimal>("_shippingCost").HasColumnName("ShippingCost");
        builder.Property<decimal>("_totalCost").HasColumnName("TotalCost");
        builder.Property<string>("_currency").HasColumnName("Currency");
        builder.Property<decimal>("_exchangeRate").HasColumnName("ExchangeRate");
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");

        builder.OwnsMany<OrderItem>("_orderItems", y =>
        {
            y.WithOwner().HasForeignKey("OrderId");
            y.ToTable("OrderItems", "order");
            y.HasKey("Id");
            y.Property<OrderId>("OrderId");
            y.Property<Guid>("_productId").HasColumnName("ProductId");
            y.Property<int>("_quantity").HasColumnName("Quantity");
            y.Property<decimal>("_price").HasColumnName("Price");
        });
    }
}