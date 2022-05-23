using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eShopCmc.Domain.Countries;

namespace eShopCmc.Infrastructure.Countries;

public class CountryRepository : ICountryRepository
{
    private readonly EShopCmcContext _context;
    private readonly ILogger<CountryRepository> _logger;
    public CountryRepository(EShopCmcContext context, ILogger<CountryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Country>> GetCountriesAsync(CancellationToken ct)
    {
        try
        {
            // TODO: Find a better way to seed the database 
            await SeedCountriesData(ct); 
            return await _context.Countries.ToListAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError($"GetCountriesAsync -> Error - {ex.Message}");
            throw;
        }
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