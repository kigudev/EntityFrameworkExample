using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.Data.Configurations
{
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b => b.Url)
              .IsRequired();

            builder.Property(b => b.Rating)
                .HasDefaultValue(3);

        }
    }
}