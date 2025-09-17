namespace JuiceGo.Application.Products;

internal class ProductsService(IProductsRepository productsRepository, ILogger<ProductsService> logger) : IProductsService
{
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        logger.LogInformation("Getting all products");
        var products = await productsRepository.GetAllAsync();
        return products;
    }
}
