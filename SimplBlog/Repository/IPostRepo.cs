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
        List<Post> GetListPost();
        List<Post> GetListPostByCategory(int? id);
        List<Post> GetListPostForPaging(QueryParams queryParams, out int totalItems);
        Post GetDetailPost(int? id);
        int GetAllPostsNumber();
    }
}
