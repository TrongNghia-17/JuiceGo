namespace JuiceGo.Infrastructure.FluentConfig;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> modelBuilder)
    {
        modelBuilder.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
    }
}
