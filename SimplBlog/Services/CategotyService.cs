using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplBlog.Repository;
using SimplBlog.ViewModels;

namespace SimplBlog.Services
{
    public class CategotyService : ICategoryService
    {
        private readonly IPostRepo _postRepo;
        public CategotyService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public PagedList<Post> FindAllPostByCategory<Post>(QueryParams queryParams,int id)
        {
            var data = _postRepo.GetListPostCateForPaging(queryParams, id, out int _totalItems);
            var totalItems = _totalItems;
            return new PagedList<Post>(data, totalItems, queryParams.CurrentPage, queryParams.PageItems);
           
        }
    }
}
