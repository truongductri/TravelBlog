using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplBlog.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SimplBlog.Repository
{
    public class PostRepo : IPostRepo
    {
        private BloggingContext _context;
        public PostRepo(BloggingContext context)
        {
            _context = context;
        }

        public Post GetDetailPost(int? id)
        {
            return _context.Posts.SingleOrDefault(x => x.PostId == id && x.Published == true);
        }

        public List<Post> GetListPostCateForPaging(QueryParams queryParams, int id,out int totalItems)
        {
            var query = _context.Posts.Where(x => x.Published == true && x.CategoryId == id);
            totalItems = query.Count();
            var listPost = query.OrderByDescending(x => x.PostId).Skip(queryParams.CurrentPage * queryParams.PageItems).Take(queryParams.PageItems).ToList();
            return listPost;
        }
        
        public List<Post> GetListPostForPaging(QueryParams queryParams, out int totalItems)
        {
            var query = _context.Posts.Where(x => x.Published == true);
            totalItems = query.Count();
            var listPost = query.OrderByDescending(x => x.PostId).Skip(queryParams.CurrentPage * queryParams.PageItems).Take(queryParams.PageItems).ToList();
            return listPost;
        }

        public List<Post> GetRecentPosts()
        {
           return _context.Posts.FromSql("GetRecentPosts").ToList();
        }
    }
}
 