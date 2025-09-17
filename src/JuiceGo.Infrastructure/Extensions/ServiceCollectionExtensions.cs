using JuiceGo.Infrastructure.Persistence;
using JuiceGo.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JuiceGo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("JuiceGoDb");
        services.AddDbContext<JuiceGoDbContext>(options =>
            options.UseNpgsql(connectionString)
                .LogTo(Console.WriteLine,
                        [DbLoggerCategory.Database.Command.Name],
                        LogLevel.Information)
                .EnableSensitiveDataLogging());

        services.AddScoped<IJuiceGoSeeder, JuiceGoSeeder>();
    }
}
