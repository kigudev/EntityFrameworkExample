using Microsoft.EntityFrameworkCore;
using MyPetStore.Entities;

namespace MyPetStore.Data
{
    public class MyPetStoreContext : DbContext
    {
        // cada DbSet representa una tabla en la base de datos
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPetStoreDb;Integrated Security=True");
        }
    }
}