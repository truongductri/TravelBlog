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

      
        public List<SimplBlog.Models.CategoryBl> GetSpecialNews()
        {
            
            try
            {
                List<SimplBlog.Models.CategoryBl> qGetSpecialNews = _blContext.CategoryBls.ToList();             
                return qGetSpecialNews;
                
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
