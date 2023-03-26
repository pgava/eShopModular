using EShopModular.Modules.Orders.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopModular.Modules.Orders.Infrastructure.Domain.Countries;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries", "order");

        builder.HasKey(x => x.Id);

        builder.Property<string>("_countryName").HasColumnName("CountryName");
        builder.Property<string>("_currencyCode").HasColumnName("CurrencyCode");
        builder.Property<string>("_currencySymbol").HasColumnName("CurrencySymbol");
        builder.Property<decimal>("_exchangeRate").HasColumnName("ExchangeRate");
    }
}