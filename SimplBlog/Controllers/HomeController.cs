using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplBlog.Repository;
using SimplBlog.Models;

namespace SimplBlog.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepo _postRepo;
        public HomeController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        public IActionResult Index()
        {
            var lstPost = _postRepo.GetListPost();
            return View(lstPost);
        }
        
    }
}