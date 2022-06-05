using eShopCmc.Application.Configuration.Queries;
using eShopCmc.Domain.Countries;

namespace eShopCmc.Application.Countries.GetCountries;

public class GetAllCountriesQueryHandler : IQueryHandler<GetAllCountriesQuery, List<CountryViewModel>>
{
    private readonly ICountryRepository _countryRepository;
    
    public GetAllCountriesQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    
    public async Task<List<CountryViewModel>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);
        
        return countries.Select(x => new CountryViewModel
        {
            Id = x.Id,
            Currency = x.CurrencySymbol,
            CountryName = x.CountryName,
            ExchangeRate = x.ExchangeRate
        }).ToList();
    }
}