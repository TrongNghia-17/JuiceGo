namespace JuiceGo.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productsService.GetAllProducts();
        return Ok(products);
    }
}
