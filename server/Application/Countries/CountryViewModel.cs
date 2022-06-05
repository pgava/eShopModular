namespace eShopCmc.Application.Countries;

public class CountryViewModel
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
}
