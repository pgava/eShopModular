namespace EShopModular.Api;

internal static class CreateConfiguration
{
    public static IConfiguration GetConfiguration(WebApplicationBuilder builder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables("eShop_")
            .Build();

        return configuration;
    }
}