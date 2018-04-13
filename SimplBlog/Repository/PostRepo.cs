using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplBlog.ViewModels;

namespace SimplBlog.Repository
{
    public class PostRepo : IPostRepo
    {
        private BloggingContext _context;
        public PostRepo(BloggingContext context)
        {
            _context = context;
        }

        public List<Post> GetListPost()
        {
            return _context.Posts.Where(x => x.Published == true && x.Published == true).ToList();
        }
        public List<Post> GetListPostByCategory(int? id)
        {
            return _context.Posts.Where(x => x.CategoryId == id && x.Published == true).ToList();

        }
        public Post GetDetailPost(int? id)
        {
            return _context.Posts.SingleOrDefault(x => x.PostId == id && x.Published == true);
        }
        public int GetAllPostsNumber()
        {
            return _context.Posts.Count(x => x.Published == true);
        }

        public List<Post> GetListPostForPaging(QueryParams queryParams, out int totalItems)
        {
            var query = _context.Posts.Where(x => x.Published == true);
            totalItems = query.Count();
            var listPost = query.OrderByDescending(x => x.PostId).Skip(queryParams.CurrentPage * queryParams.PageItems).Take(queryParams.PageItems).ToList();
            return listPost;
        }
    }
}
 