namespace JuiceGo.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(
    ILogger<GetProductByIdQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper
    ) : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting product by id: {request.Id}");
        var product = await productsRepository.GetByIdAsync(request.Id);
        var productDto = mapper.Map<ProductDto?>(product);

        return productDto;
    }
}
