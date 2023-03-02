namespace eShopModular.Modules.Orders.Application.Countries;

public class CountryDto
{
    public CountryDto(Guid id, string currency, string countryName, decimal exchangeRate)
    {
        Id = id;
        CountryName = countryName;
        ExchangeRate = exchangeRate;
        Currency = currency;
    }
    
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
}
