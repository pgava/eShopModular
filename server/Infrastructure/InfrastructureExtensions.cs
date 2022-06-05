using eShopCmc.Domain.Countries;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using eShopCmc.Infrastructure.Countries;
using eShopCmc.Infrastructure.Orders;
using eShopCmc.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCmc.Infrastructure;

public static class InfrastructureExtensions
{
    private const string EShopConnectionString = "eShopDb";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, EShopCmcContext>(options =>
         {
             options.UseSqlServer(configuration.GetConnectionString(EShopConnectionString));
         });

        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        
        return services;
    }
}
