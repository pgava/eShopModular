using eShopModular.Modules.Orders.Application.Configuration.Queries;
using eShopModular.Modules.Orders.Domain.Countries;
using Serilog;

namespace eShopModular.Modules.Orders.Application.Countries.GetCountries;

public class GetAllCountriesQueryHandler : IQueryHandler<GetAllCountriesQuery, List<CountryDto>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILogger _logger;

    public GetAllCountriesQueryHandler(ICountryRepository countryRepository, ILogger logger)
    {
        _countryRepository = countryRepository;
        _logger = logger;
    }
    
    public async Task<List<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"Getting all countries");
        
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);
        
        return countries.Select(x => new CountryDto
        (
            x.Id.Value,
            x.CurrencySymbol,
            x.CountryName,
            x.ExchangeRate
        )).ToList();
    }
}