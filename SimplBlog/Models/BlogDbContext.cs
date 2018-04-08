using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }
        public DbSet<CategoryBl> CategoryBls { get; set; }
        public DbSet<Post> Posts { get; set; }
        
    }

    public class CategoryBl
    {
        [Key]
        public int CateBlId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CateBlId { get; set; }
        
    }

   

}
