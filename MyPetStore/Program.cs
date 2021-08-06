using MyPetStore.Data;
using MyPetStore.Entities;
using System;
using System.Linq;

namespace MyPetStore
{
    class Program
    {
        static void Main(string[] args)
        {
            using MyPetStoreContext context = new();

            //var squeakyBone = new Product
            //{
            //    Name = "Huesito con silbato",
            //    Price = 4.99m
            //};

            //context.Products.Add(squeakyBone);

            //var tennisBalls = new Product
            //{
            //    Name = "Pelotas de tenis pack de 3",
            //    Price = 9.99m
            //};

            // Se puede agregar un registro a la bd sin necesidad de especificar el dbset (tabla) ya que 
            // entity framework lo infiere
            //context.Add(tennisBalls);


            //context.SaveChanges();


            // solicitar los productos que el precio sea mayor a 5 ordenados por nombre
            // LINQ usando métodos de extensión con expresiones lambda también se le conoce como Fluent API
            var products = context.Products
                .Where(p => p.Price >= 5m)
                .OrderBy(p => p.Name);

            foreach (var product in products)
            {
                Console.WriteLine($"Id:\t{product.Id}");
                Console.WriteLine($"Name:\t{product.Name}");
                Console.WriteLine($"Price:\t{product.Price}");
                Console.WriteLine(new string('-', 20));
            }


            // hacer consulta en linq syntax donde el nombre sea igual a "huesito"
            var products2 = from product in context.Products
                            where product.Name.Contains("Huesito")
                            orderby product.Name
                            select product;

            foreach (var product in products2)
            {
                Console.WriteLine($"Id:\t{product.Id}");
                Console.WriteLine($"Name:\t{product.Name}");
                Console.WriteLine($"Price:\t{product.Price}");
                Console.WriteLine(new string('-', 20));
            }

            Product pelota = context.Products
                .Where(c => c.Name == "Pelotas de tenis pack de 3")
                .FirstOrDefault();

            if(pelota != null)
            {
                pelota.Price = 12.99m;
            }

            //context.SaveChanges();

            // Esto es lo mismo que la forma de consultar y validar el producto pelota
            Product huesito = context.Products
                .FirstOrDefault(c => c.Name == "Huesito con silbato");

            if(huesito is Product) 
                context.Remove(huesito);
            
            
            context.SaveChanges();



        }
    }
}
