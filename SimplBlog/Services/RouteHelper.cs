using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplBlog.Models;

namespace SimplBlog.Services
{
    public class RouteHelper
    {
        public static string LinkPosts(bool hasPagingFormat = false)
        {
            return string.Format("/posts{0}", WithPagingFormat(hasPagingFormat));
        }
        public static string WithPagingFormat(bool hasPagingFormat)
        {
            return hasPagingFormat ? PagingFormat() : string.Empty;
        }
        public static string PagingFormat()
        {
            return "/p{0}";
        }
        public static string BreadcrumbPosts()
        {
            var str = string.Empty;
            str += "<nav id='breadcrumb'>";
            str += "<ul>";
            //str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='1'></li>", RouteHelper.LinkHomePage(), "Home");
            str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='2'></li>", RouteHelper.LinkPosts(), "Posts");
            str += "</ul>";
            str += "</nav>";
            return str;
        }
    }
}
