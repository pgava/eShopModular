#nullable disable
using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Countries;

// Cannot make this class immutable because of EF Core
public class Country : Entity, IAggregateRoot
{
    public CountryId Id { get; private set; }

    // private string _countryName;
    // private string _currencyCode;
    // private string _currencySymbol;
    // private decimal _exchangeRate;
    private Country()
    {
    }
}
#nullable enable