using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EShopModular.Modules.Orders.Application.Countries;
using EShopModular.Modules.Orders.Application.Countries.GetCountries;
using EShopModular.Modules.Orders.Domain.Countries;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;

namespace EShopModular.UnitTests.Countries;

public class GetAllCountriesTests
{
    private readonly Mock<ICountryRepository> _countryRepository;
    private readonly Mock<ILogger> _logger;
    private readonly List<Country> _countries = new ()
    {
        new Country(new CountryId(Guid.NewGuid()), "country 1", "A", "$", 0.1M),
        new Country(new CountryId(Guid.NewGuid()), "country 2", "B", "$", 0.2M),
    };

    public GetAllCountriesTests()
    {
        _countryRepository = new Mock<ICountryRepository>();
        _logger = new Mock<ILogger>();
    }

    [Fact]
    public async void GetCountries_AllAvailableCountriesAreReturned()
    {
        // Arrange
        _countryRepository.Setup(s => s.GetCountriesAsync(CancellationToken.None))
            .ReturnsAsync(_countries);
        var sut = new GetAllCountriesQueryHandler(_countryRepository.Object, _logger.Object);

        // Act
        var countries = await sut.Handle(new GetAllCountriesQuery(), CancellationToken.None);

        // Assert
        countries.Should().BeEquivalentTo(GetCountriesViewModel());
    }

    private List<CountryDto> GetCountriesViewModel()
    {
        return _countries.Select(c => new CountryDto(
            c.Id.Value,
            c.CurrencySymbol,
            c.CountryName,
            c.ExchangeRate)).ToList();
    }
}