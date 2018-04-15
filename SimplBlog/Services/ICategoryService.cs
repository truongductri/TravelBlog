using SimplBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Services
{
    public interface ICategoryService
    {
        PagedList<Post> FindAllPostByCategory<Post>(QueryParams queryParams,int id);

    }
}
