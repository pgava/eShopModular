using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Application.Countries;
using EShopModular.Modules.Orders.Application.Countries.GetCountries;
using Microsoft.AspNetCore.Mvc;

namespace EShopModular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IEShopOrdersModule _eShopOrdersModule;

        public CountryController(IEShopOrdersModule eShopOrdersModule)
        {
            _eShopOrdersModule = eShopOrdersModule;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CountryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountries(int? page, int? perPage)
        {
            var countries = await _eShopOrdersModule.ExecuteQueryAsync(
                new GetAllCountriesQuery());

            return Ok(countries);
        }
    }
}
