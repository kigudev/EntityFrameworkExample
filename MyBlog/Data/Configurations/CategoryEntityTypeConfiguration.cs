using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name)
               .HasMaxLength(10)
               .IsRequired();

            builder.HasData(
                new Category[]
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Espectác."
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Autos"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Deportes"
                    }
                }
            );
        }
    }
}