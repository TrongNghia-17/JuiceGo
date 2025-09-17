namespace JuiceGo.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
    }
}
