using JuiceGo.Domain.Entities;
using JuiceGo.Infrastructure.FluentConfig;
using Microsoft.EntityFrameworkCore;

namespace JuiceGo.Infrastructure.Persistence;

internal class JuiceGoDbContext(DbContextOptions<JuiceGoDbContext> options) : DbContext(options)
{
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);                

        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());

    }
}
