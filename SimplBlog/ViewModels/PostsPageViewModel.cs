using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.ViewModels
{
    public class PostsPageViewModel
    {
        public PagedList<Post> ListPost { get; set; }
    }
}
