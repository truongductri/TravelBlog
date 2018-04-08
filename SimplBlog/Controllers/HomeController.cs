using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplBlog.Models;
using SimplBlog.Extensions;

namespace SimplBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BloggingContext _context;

        public HomeController(BloggingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryBls.ToListAsync());
        }
        public IActionResult Archive()
        {
            
            return View();
        }
        public async Task<IActionResult> About()
        {
            this.HttpContext.Response.Cookies.Append("example_cookie", "cookie_value");
            ViewData["Message"] = $"Your application description page. {HttpContext.Session.Get<string>("User")}";
            return View(await _context.CategoryBls.Take(4).ToListAsync());
        }
        

        public IActionResult Contact()
        {
            HttpContext.Session.Set<string>("User", "Thanh");
            var cookie_value = string.Empty;
            this.HttpContext.Request.Cookies.TryGetValue("example_cookie", out cookie_value);
            ViewData["Message"] = $"Your contact page. Cookie value is {cookie_value}";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
