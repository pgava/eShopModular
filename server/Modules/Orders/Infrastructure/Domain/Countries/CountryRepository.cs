using EShopModular.Modules.Orders.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShopModular.Modules.Orders.Infrastructure.Domain.Countries;

public class CountryRepository : ICountryRepository
{
    private readonly EShopOrdersContext _context;
    private readonly ILogger _logger;

    public CountryRepository(EShopOrdersContext context, ILogger logger)
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