using Microsoft.EntityFrameworkCore;
using eShopModular.Domain.Countries;
using Serilog;

namespace eShopModular.Infrastructure.Countries;

public class CountryRepository : ICountryRepository
{
    private readonly EShopCmcContext _context;
    private readonly ILogger _logger;

    public CountryRepository(EShopCmcContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Country>> GetCountriesAsync(CancellationToken ct)
    {
        try
        {
            return await _context.Countries.ToListAsync(ct);
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error getting countries");
            throw;
        }
    }
}