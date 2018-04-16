﻿using Microsoft.AspNetCore.Mvc;
using SimplBlog.Models;
using SimplBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Components 
{
    public class RecentPosts : ViewComponent
    {
        private readonly IPostRepo _postRepo;
       
        public RecentPosts(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cateLst = _postRepo.GetRecentPosts();

            return View(cateLst);
        }
    }
}
