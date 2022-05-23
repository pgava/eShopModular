namespace eShopCmc.Domain.Countries;

public class Country
{
    public int Id { get; set; }
    public string CountryName { get; set; }
    public string Currency { get; set; }
    public decimal ExchangeRate { get; set; }
}
