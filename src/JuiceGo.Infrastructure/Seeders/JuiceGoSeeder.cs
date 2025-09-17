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
                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Products.Any())
            {
                var categories = await dbContext.Categories.ToListAsync();
                var products = GetProducts(categories);
                await dbContext.Products.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Category> GetCategories()
    {
        return
        [
            new Category { Id = Guid.NewGuid(), Name = "Nước Ép Trái Cây" },
            new Category { Id = Guid.NewGuid(), Name = "Sinh Tố" },
            new Category { Id = Guid.NewGuid(), Name = "Trà Trái Cây" }
        ];
    }

    private IEnumerable<Product> GetProducts(List<Category> categories)
    {
        var categoryDict = categories.ToDictionary(c => c.Name, c => c.Id);

        return
        [
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Nước Ép Cam Tươi",
                Description = "Nước ép cam nguyên chất 100%, không đường, giàu vitamin C.",
                Price = 35000,
                StockQuantity = 100,
                ImageUrl = "/images/orange-juice.jpg",
                CategoryId = categoryDict["Nước Ép Trái Cây"]
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sinh Tố Bơ",
                Description = "Sinh tố bơ sánh mịn, béo ngậy, kết hợp với sữa đặc và đá xay.",
                Price = 45000,
                StockQuantity = 50,
                ImageUrl = "/images/avocado-smoothie.jpg",
                CategoryId = categoryDict["Sinh Tố"]
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Trà Đào Cam Sả",
                Description = "Sự kết hợp hoàn hảo giữa vị đào ngọt, cam thơm và sả thanh mát.",
                Price = 42000,
                StockQuantity = 70,
                ImageUrl = "/images/peach-tea.jpg",
                CategoryId = categoryDict["Trà Trái Cây"]
            }
        ];
    }
}
