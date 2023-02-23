using eShopModular.Application.Configuration.Queries;
using eShopModular.Domain.Countries;
using Serilog;

namespace eShopModular.Application.Countries.GetCountries;

public class GetAllCountriesQueryHandler : IQueryHandler<GetAllCountriesQuery, List<CountryViewModel>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILogger _logger;

    public GetAllCountriesQueryHandler(ICountryRepository countryRepository, ILogger logger)
    {
        _countryRepository = countryRepository;
        _logger = logger;
    }
    
    public async Task<List<CountryViewModel>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"Getting all countries");
        
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);
        
        return countries.Select(x => new CountryViewModel
        (
            x.Id.Value,
            x.CurrencySymbol,
            x.CountryName,
            x.ExchangeRate
        )).ToList();
    }
}