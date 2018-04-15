using SimplBlog.Models;
using SimplBlog.Repository;
using SimplBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;
        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
       
        public PagedList<Post> FindAllPost<Post>(QueryParams queryParams)
        {
            var data = _postRepo.GetListPostForPaging(queryParams, out int _totalItems);
            var totalItems = _totalItems;
            return new PagedList<Post>(data, totalItems, queryParams.CurrentPage, queryParams.PageItems);
        }
    }
}
 