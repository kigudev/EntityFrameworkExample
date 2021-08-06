using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            using MyBlogContext context = new();

            var blog = new Blog
            {
                Url = "https://yahoo.com",
                Rating = 4,
                Posts = new List<Post>
                {
                    new Post
                    {
                        Content = "mi contenido yahoo 1",
                        Title = "mi post yahoo 1"
                    },
                     new Post
                    {
                        Content = "mi contenido yahoo 2",
                        Title = "mi post yahoo 2"
                    },
                      new Post
                    {
                        Content = "mi contenido yahoo 3",
                        Title = "mi post yahoo 3"
                    },
                }
            };

            var postAparte = new Post
            {
                Content = "mi contenido yahoo 3",
                Title = "mi post yahoo 3"
            };

            var blog1 = new Blog
            {
                Url = "https://wikipedia.com",
                Rating = 4,
                Posts = new List<Post>
                {
                    new Post
                    {
                        Content = "mi contenido wikipedia 1",
                        Title = "mi post wikipedia 1"
                    },
                     new Post
                    {
                        Content = "mi contenido wikipedia 2",
                        Title = "mi post wikipedia 2"
                    },
                      new Post
                    {
                        Content = "mi contenido wikipedia 3",
                        Title = "mi post wikipedia 3"
                    },
                }
            };

            // crear una consulta de linq que agrupe los blogs por categoría y los ordene por rating.
            // y a su vez, mostrar el nombre y fecha de publicación de sus posts

            // categoria
            //      blogs
            //          publicacion
            //          publicacion
            //          publicacion
            //      blogs
            //          publicacion
            //          publicacion
            // categoria
            //      blogs
            //          publicacion
            //          publicacion
            //          publicacion
            var categoriesGroup = context.Category.Include(c => c.Blogs).ThenInclude(c => c.Posts);

            Console.WriteLine("Query con includes: " + categoriesGroup.ToQueryString());

            foreach (var c in categoriesGroup)
            {
                Console.WriteLine($"Category: {c.Name}");

                foreach (var b in c.Blogs.OrderBy(c => c.Rating))
                {
                    Console.WriteLine($"\tBlog url: {b.Url}");

                    foreach (var p in b.Posts)
                    {
                        Console.WriteLine($"\t\tPost: {p.PublishedDate:dd/MMM/yy} - {p.Title}");

                    }
                }

                Console.WriteLine(new string('-', 50));
            }

            var categoriesWithPostsQuery = context.Blogs
                .Select(c => new
                {
                    c.Url,
                    c.Rating,
                    Category = c.Category.Name,
                    Posts = c.Posts.Select(p => new
                    {
                        p.PublishedDate,
                        p.Title
                    })
                }).OrderBy(c => c.Rating);

            Console.WriteLine("Query con select especifico: " + categoriesWithPostsQuery.ToQueryString());

            // Esto tira un invalidOperationException ya que el groupBy se está intentando ejecutar 
            // en la base de datos bajo una propiedad que no existe
            var categoriesWithPosts = categoriesWithPostsQuery
                .GroupBy(c => c.Category)
                .ToList();


            // Para corregir eso hay que traernos el listado a memoria haciendo uso del ToList() o ToArray()
            // y luego asi podremos agruparlos por la propiedad categoría.
            var categoriesWithPosts2 = categoriesWithPostsQuery
               .ToList()
               .GroupBy(c => c.Category);


            foreach (var c in categoriesWithPosts)
            {
                Console.WriteLine($"Category: {c.Key}");

                foreach (var b in c)
                {
                    Console.WriteLine($"\tBlog url: {b.Url}");

                    foreach (var p in b.Posts)
                    {
                        Console.WriteLine($"\t\tPost: {p.PublishedDate:dd/MMM/yy} - {p.Title}");

                    }
                }

                Console.WriteLine(new string('-', 50));
            }
        }







        public static void EjercicioBlogs(MyBlogContext context)
        {
            // crear una consulta de linq que agrupe los blogs por categoría y los ordene por rating.
            // y a su vez, mostrar el nombre y fecha de publicación de sus posts

            // categoria
            //      blogs
            //          publicacion
            //          publicacion
            //          publicacion
            //      blogs
            //          publicacion
            //          publicacion
            // categoria
            //      blogs
            //          publicacion
            //          publicacion
            //          publicacion
            var categoriesGroup = context.Category.Include(c => c.Blogs).ThenInclude(c => c.Posts);

            Console.WriteLine(categoriesGroup.ToQueryString());

            foreach (var c in categoriesGroup)
            {
                Console.WriteLine($"Category: {c.Name}");

                foreach (var b in c.Blogs)
                {
                    Console.WriteLine($"\tBlog url: {b.Url}");

                    foreach (var p in b.Posts)
                    {
                        Console.WriteLine($"\t\tPost: {p.PublishedDate:dd/MMM/yy} - {p.Title}");

                    }
                }

                Console.WriteLine(new string('-', 50));
            }




            var categoriesWithPostsQuery = context.Blogs
               .Select(c => new
               {
                   c.Url,
                   c.Rating,
                   Category = c.Category.Name,
                   Posts = c.Posts.Select(p => new
                   {
                       p.PublishedDate,
                       p.Title
                   })
               })
               .OrderBy(c => c.Rating);

            Console.WriteLine(categoriesWithPostsQuery.ToQueryString());


            var categoriesWithPosts = categoriesWithPostsQuery
                .ToList()
                .GroupBy(c => c.Category);

            foreach (var c in categoriesWithPosts)
            {
                Console.WriteLine($"Category: {c.Key}");

                foreach (var b in c)
                {
                    Console.WriteLine($"\tBlog url: {b.Url}");

                    foreach (var p in b.Posts)
                    {
                        Console.WriteLine($"\t\tPost: {p.PublishedDate:dd/MMM/yy} - {p.Title}");

                    }
                }

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
