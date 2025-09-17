namespace JuiceGo.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(
    ILogger<GetAllProductsQueryHandler> logger,
    IMapper mapper,
    IProductsRepository productsRepository
    ) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all products");
        var products = await productsRepository.GetAllAsync();
        var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }
}
