namespace JuiceGo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("JuiceGoDb");
        services.AddDbContext<JuiceGoDbContext>(options =>
            options.UseNpgsql(connectionString));
        //.LogTo(Console.WriteLine,
        //        [DbLoggerCategory.Database.Command.Name],
        //        LogLevel.Information)
        //.EnableSensitiveDataLogging());

        services.AddScoped<IJuiceGoSeeder, JuiceGoSeeder>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
    }
}
