using MyBlog.Data;
using MyBlog.Entities;
using System;
using System.Collections.Generic;

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
        }
    }
}
