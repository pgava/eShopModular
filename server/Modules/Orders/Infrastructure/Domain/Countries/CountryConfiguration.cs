using eShopModular.Modules.Orders.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopModular.Modules.Orders.Infrastructure.Domain.Countries;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries", "country");

        builder.HasKey(x => x.Id);
    }
}