using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplBlog.Models;

namespace SimplBlog.Services
{
    public class CategoryBlServ
    {
        private readonly BloggingContext _blContext;
        public CategoryBlServ(BloggingContext blContext) {
            _blContext = blContext;
        }

      
        public List<SimplBlog.Models.Category> GetSpecialNews()
        {
            
            try
            {
                List<SimplBlog.Models.Category> qGetSpecialNews = _blContext.Categories.ToList();             
                return qGetSpecialNews;
                
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
