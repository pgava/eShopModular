using EShopModular.Common.Application.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopModular.Modules.Products.Infrastructure.Outbox;

internal class OutboxMessageEntityTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages", "product");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedNever();
    }
}