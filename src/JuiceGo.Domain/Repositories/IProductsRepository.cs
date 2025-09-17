namespace JuiceGo.Domain.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}
