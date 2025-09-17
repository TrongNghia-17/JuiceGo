namespace JuiceGo.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    ILogger<CreateProductCommandHandler> logger,
    IMapper mapper,
    IProductsRepository productsRepository) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new product: {ProductName}", request.Name);

        var product = mapper.Map<Product>(request);

        Guid guid = await productsRepository.Create(product);
        return guid;
    }
}
