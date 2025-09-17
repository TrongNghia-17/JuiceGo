namespace JuiceGo.Application.Products;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetAllProducts();
}