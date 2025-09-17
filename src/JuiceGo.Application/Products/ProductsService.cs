namespace JuiceGo.Application.Products;

internal class ProductsService(IProductsRepository productsRepository,
    ILogger<ProductsService> logger,
    IMapper mapper) : IProductsService
{
    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        logger.LogInformation("Getting all products");
        var products = await productsRepository.GetAllAsync();
        var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productDtos!;
    }
}
