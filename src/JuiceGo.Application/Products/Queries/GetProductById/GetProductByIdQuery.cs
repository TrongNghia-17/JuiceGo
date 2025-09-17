namespace JuiceGo.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery(Guid id) : IRequest<ProductDto?>
{
    public Guid Id { get; } = id;
}
