using Microsoft.EntityFrameworkCore;
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
        return await _context.Countries.ToListAsync(ct);
    }
}