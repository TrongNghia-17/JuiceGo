namespace JuiceGo.Infrastructure.Repositories;

internal class ProductsRepository(JuiceGoDbContext dbContext) : IProductsRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }
}
