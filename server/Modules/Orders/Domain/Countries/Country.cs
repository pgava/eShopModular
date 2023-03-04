namespace EShopModular.Modules.Orders.Domain.Countries;

public class Country
{
    public Country(CountryId id, string countryName, string currencyCode, string currencySymbol, decimal exchangeRate)
    {
        Id = id;
        CountryName = countryName;
        CurrencyCode = currencyCode;
        CurrencySymbol = currencySymbol;
        ExchangeRate = exchangeRate;
    }

    public CountryId Id { get; set; }

    public string CountryName { get; set; }

    public string CurrencyCode { get; set; }

    public string CurrencySymbol { get; set; }

    public decimal ExchangeRate { get; set; }
}
