namespace EShopModular.Modules.Orders.Application.Countries;

public class CountryDto
{
    public CountryDto(string countryName, string currency, decimal exchangeRate)
    {
        CountryName = countryName;
        ExchangeRate = exchangeRate;
        Currency = currency;
    }

    public string CountryName { get; set; }

    public string Currency { get; set; }

    public decimal ExchangeRate { get; set; }
}
