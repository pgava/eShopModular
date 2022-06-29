using Microsoft.EntityFrameworkCore;
using eShopCmc.Domain.Countries;
using Serilog;

namespace eShopCmc.Infrastructure.Countries;

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