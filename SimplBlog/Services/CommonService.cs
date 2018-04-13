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
    public class CommonService : ICommonService
    {
        private readonly IPostRepo _postRepo;
        public CommonService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
       

        public PagedList<Post> FindAll<Post>(QueryParams queryParams)
        {
            var data = _postRepo.GetListPostForPaging(queryParams, out int _totalItems);
            var totalItems = _totalItems;
            return new PagedList<Post>(data, totalItems, queryParams.CurrentPage, queryParams.PageItems);
        }
    }
}
 