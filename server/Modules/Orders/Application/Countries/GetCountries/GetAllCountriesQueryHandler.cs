using Dapper;
using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Queries;
using Serilog;

namespace EShopModular.Modules.Orders.Application.Countries.GetCountries;

internal class GetAllCountriesQueryHandler : IQueryHandler<GetAllCountriesQuery, List<CountryDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ILogger _logger;

    public GetAllCountriesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, ILogger logger)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _logger = logger;
    }

    public async Task<List<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"Getting all countries");

        var connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<CountryDto>(
            "SELECT " +
            $"[Country].[CountryName] AS [{nameof(CountryDto.CountryName)}],  " +
            $"[Country].[CurrencySymbol] AS [{nameof(CountryDto.Currency)}], " +
            $"[Country].[ExchangeRate] AS [{nameof(CountryDto.ExchangeRate)}] " +
            "FROM [order].[Countries] AS [Country]")).AsList();
    }
}