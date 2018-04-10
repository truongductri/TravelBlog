using Microsoft.AspNetCore.Mvc;
using SimplBlog.Models;
using SimplBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplBlog.Components
{
    //[ViewComponent(Name = "Categories")]
    public class Categories : ViewComponent
    {
        private ICateRepo _cateRepo;
        
        public Categories(ICateRepo cateRepo)
        {
            _cateRepo = cateRepo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cateLst = new List<Category>();
            cateLst =  _cateRepo.GetAll();
           
            return  View(cateLst);
        }
       
    }
   
}
