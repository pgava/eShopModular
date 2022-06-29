using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using eShopCmc.Application.Countries;
using eShopCmc.Application.Countries.GetCountries;
using eShopCmc.Domain.Countries;
using FluentAssertions;
using Moq;
using Serilog;
using Xunit;

namespace eShopCmc.UnitTests.Countries
{
    public class GetAllCountriesTests
    {
        private readonly Mock<ICountryRepository> _countryRepository;
        private readonly Mock<ILogger> _logger;
        private readonly List<Country> _countries = new()
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

        private List<CountryViewModel> GetCountriesViewModel()
        {
            return _countries.Select(c => new CountryViewModel
            (
                c.Id.Value,
                c.CurrencySymbol,
                c.CountryName,
                c.ExchangeRate
            )).ToList();
            
        }
    }
}
