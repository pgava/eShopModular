using EShopModular.Common.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopModular.Modules.Products.Infrastructure.InternalCommands;

internal class InternalCommandEntityTypeConfiguration : IEntityTypeConfiguration<InternalCommand>
{
    public void Configure(EntityTypeBuilder<InternalCommand> builder)
    {
        builder.ToTable("InternalCommands", "product");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedNever();
    }
}