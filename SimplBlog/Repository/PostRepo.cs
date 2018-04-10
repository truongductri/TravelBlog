using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Repository
{
    public class PostRepo: IPostRepo
    {
        private BloggingContext _context;
        public PostRepo(BloggingContext context)
        {
            _context = context;
        }

        public List<Post> GetListPost()
        {
            return _context.Posts.Where(x => x.Published == true).ToList();
        }
        public List<Post> GetListPostByCategory(int categoryId)
        {
            return _context.Posts.Where(x => x.CategoryId == categoryId).ToList();
        }
        public List<Post> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
