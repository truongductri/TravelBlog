
using SimplBlog.Models;
using SimplBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplBlog.Services
{
    public interface ICommonService 
    {
        PagedList<Post> FindAll<Post>(QueryParams queryParams);
        
    }
}
