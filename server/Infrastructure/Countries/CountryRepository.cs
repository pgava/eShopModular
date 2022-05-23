using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eShopCmc.Domain.Countries;

namespace eShopCmc.Infrastructure.Countries;

public class CountryRepository : ICountryRepository
{
    private readonly EShopCmcContext _context;
    public CountryRepository(EShopCmcContext context)
    {
        _context = context;
    }

    public async Task<List<Country>> GetCountriesAsync(CancellationToken ct)
    {
        // TODO: Find a better way to seed the database 
        await SeedCountriesData(ct); 
        return await _context.Countries.ToListAsync(ct);
    }

    private async Task SeedCountriesData(CancellationToken ct)
    {
        if (_context.Countries.Any())
        {
            return;
        }
        
        _context.Countries.AddRange(
            new Country {Id = 1, CountryName = "Germany", Currency = "€", ExchangeRate = 0.67M},
            new Country {Id = 2, CountryName = "United States", Currency = "$", ExchangeRate = 0.70M},
            new Country {Id = 3, CountryName = "China", Currency = "¥", ExchangeRate = 4.75M}
        );

        await _context.SaveChangesAsync(ct);
    }
}