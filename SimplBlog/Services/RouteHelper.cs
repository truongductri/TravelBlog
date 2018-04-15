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
        public static string LinkCategory(bool hasPagingFormat = false)
        {
            return string.Format("/Categories{0}", WithPagingFormatDetail(hasPagingFormat));
        }
       
        public static string LinkHome(bool hasPagingFormat = false)
        {
            return string.Format("/home{0}", WithPagingFormat(hasPagingFormat));
        }


        public static string WithPagingFormat(bool hasPagingFormat)
        {
            return hasPagingFormat ? PagingFormat() : string.Empty;
        }

        public static string PagingFormat()
        {
            return "/p{0}";
        }


        public static string WithPagingFormatDetail(bool hasPagingFormat)
        {
            return hasPagingFormat ? PagingFormatDetail() : string.Empty;
        }
        public static string PagingFormatDetail()
        {
            return "/{0}/p{1}";
        }
        
        public static string LinkHomePage()
        {
            return string.Format("/");
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
       
        public static string BreadcrumbCategoryPosts()
        {
            var str = string.Empty;
            str += "<nav id='breadcrumb'>";
            str += "<ul>";
            //str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='1'></li>", RouteHelper.LinkHomePage(), "Home");
            str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='2'></li>", RouteHelper.LinkPosts(), "Category");
            str += "</ul>";
            str += "</nav>";
            return str;
        }
        public static string BreadcrumbPostByCategory()
        {
            var str = string.Empty;
            str += "<nav id='breadcrumb'>";
            str += "<ul>";
            str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='1'></li>", RouteHelper.LinkHomePage(), "Categories");
            str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'></a></li>","{/0}");
            str += "</ul>";
            str += "</nav>";
            return str;
        }
        public static string BreadcrumbHomePosts()
        {
            var str = string.Empty;
            str += "<nav id='breadcrumb'>";
            str += "<ul>";
            //str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='1'></li>", RouteHelper.LinkHomePage(), "Home");
            str += string.Format("<li itemprop='itemListElement' itemscope itemtype='http://schema.org/ListItem'><a itemprop='item' href='{0}'><span itemprop='name'>{1}</span></a><meta itemprop='position' content='2'></li>", RouteHelper.LinkPosts(), "Home");
            str += "</ul>";
            str += "</nav>";
            return str;
        }
    }
}
