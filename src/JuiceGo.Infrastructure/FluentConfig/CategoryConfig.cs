namespace JuiceGo.Infrastructure.FluentConfig;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> modelBuilder)
    {
        //name of table
        modelBuilder.ToTable("JuiceGo_Categories");

        //name of columns
        modelBuilder.Property(c => c.Name).HasColumnName("CategoryName");
        modelBuilder.Property(c => c.Id).HasColumnName("CategoryId");

        //primary key
        modelBuilder.HasKey(c => c.Id);

        //other validations
        modelBuilder.Property(c => c.Name).IsRequired();
        modelBuilder.Property(c => c.Name).HasMaxLength(100);

        //relations

    }
}
