using JuiceGo.Domain.Entities;
using JuiceGo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace JuiceGo.Infrastructure.Seeders;

internal class JuiceGoSeeder(JuiceGoDbContext dbContext) : IJuiceGoSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Categories.Any())
            {
                var categories = GetCategories();
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Category> GetCategories()
    {
        throw new NotImplementedException();
    }
}
