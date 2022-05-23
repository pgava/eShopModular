using eShopCmc.Application.Contracts;
using eShopCmc.Application.Countries;
using eShopCmc.Application.Countries.GetCountries;
using Microsoft.AspNetCore.Mvc;

namespace eShopCmc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IEShopCmcModule _eShopCmcModule;

        public CountryController(IEShopCmcModule eShopCmcModule)
        {
            _eShopCmcModule = eShopCmcModule;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountries(int? page, int? perPage)
        {
            var countries = await _eShopCmcModule.ExecuteQueryAsync(
                new GetAllCountriesQuery());

            return Ok(countries);
        }

    }
}
