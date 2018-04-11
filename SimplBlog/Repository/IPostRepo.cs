﻿using SimplBlog.Models;
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
        Post GetDetailPost(int? id);
    }
}
