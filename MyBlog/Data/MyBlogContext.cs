using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Configurations;
using MyBlog.Entities;

namespace MyBlog.Data
{
    public class MyBlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Category { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // esta es una forma de definir el comportamiento de una columna en una entidad
            //modelBuilder.Entity<Blog>()
            //    .Property(b => b.Url)
            //    .IsRequired();


            // esto es otra forma de definir el comportamiento de toda una entidad
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBlogDb;Integrated Security=True");
        }
    }
}