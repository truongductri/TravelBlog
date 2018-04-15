using SimplBlog.Models;
using SimplBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Repository
{
    public interface IPostRepo
    {
        List<Post> GetListPostForPaging(QueryParams queryParams, out int totalItems);
        Post GetDetailPost(int? id);
        List<Post> GetListPostCateForPaging(QueryParams queryParams, int id, out int totalItems);
        List<Post> GetRecentPosts();
      
    }
}
