using Microsoft.EntityFrameworkCore;
using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Repository
{
    public class CateRepo : ICateRepo
    {
        private BloggingContext _context;
        public CateRepo(BloggingContext context)
        {
            _context = context;
        }
        public  List<Category> GetAll()
        {
            return  _context.Categories.ToList();
        }
       
    }
}
