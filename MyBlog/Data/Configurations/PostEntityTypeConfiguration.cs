using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.Data.Configurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // cambio de nombre de la tabla
            //builder.ToTable("myposts", schema: "blogging");

            builder.Property(p => p.Content)
                 .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                 .IsRequired();

            builder.Property(p => p.Title)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .IsRequired();

            builder.Property(p => p.PublishedDate)
                .HasDefaultValueSql("getdate()");

            // esto ignora la columna Title para que no se cree en la tabla Post
            //builder.Ignore("Title");
        }
    }
}