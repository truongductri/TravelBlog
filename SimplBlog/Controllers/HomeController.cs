using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplBlog.Models;
using SimplBlog.ViewModels;
using SimplBlog.Services;

namespace SimplBlog.Controllers
{
    public class HomeController : Controller
    {
        private IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("home")]
        [Route("/")]
        [Route("home/p{page}")]
        public IActionResult Index(int page = 1)
        {
            if (page < 1) page = 1;
            var vm = new PostsPageViewModel();
            var queryParams = new QueryParams()
            {
                PageItems = 2,
                CurrentPage = page - 1
            };
            vm.ListPost = _postService.FindAllPost<Post>(queryParams);
            vm.ListPost.PagingBaseUrl = RouteHelper.LinkHome(true);
            return View(vm);
        }
        
    }
}