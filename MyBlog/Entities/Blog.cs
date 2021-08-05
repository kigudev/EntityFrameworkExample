using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}