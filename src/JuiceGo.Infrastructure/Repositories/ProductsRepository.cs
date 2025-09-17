
namespace JuiceGo.Infrastructure.Repositories;

internal class ProductsRepository(JuiceGoDbContext dbContext) : IProductsRepository
{
    public async Task<Guid> Create(Product entity)
    {
        dbContext.Products.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var product = await dbContext.Products
             .FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }
}
