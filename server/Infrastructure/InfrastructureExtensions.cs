using eShopCmc.Domain.Countries;
using eShopCmc.Domain.Orders;
using eShopCmc.Domain.Products;
using eShopCmc.Infrastructure.Countries;
using eShopCmc.Infrastructure.Orders;
using eShopCmc.Infrastructure.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCmc.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, EShopCmcContext>(options =>
         {
             options.UseInMemoryDatabase("EShopInMemoryDatabase");
         });

        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        
        return services;
    }
}
