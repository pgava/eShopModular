namespace EShopModular.Modules.Orders.Domain.Countries;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(CancellationToken ct);
}
