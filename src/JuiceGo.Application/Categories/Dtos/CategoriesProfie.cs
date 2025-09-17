namespace JuiceGo.Application.Categories.Dtos;

public class CategoriesProfie : Profile
{
    public CategoriesProfie()
    {
        CreateMap<Category, CategoryDto>();
    }
}
