using SimplBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplBlog.ViewModels
{
    public class PagedList<dynamic>
    {
        public string PagingBaseUrl { get; set; }
        public bool HasPaging { get { return TotalPage > 1; } }
        public int TotalItems { get; set; }
        public int TotalPage { get; set; }
        public int PageItems { get; set; }
        public int CurrentPage { get; set; }
        public string NextPageLink { get { return this.HasPaging && !string.IsNullOrEmpty(PagingBaseUrl) && this.CurrentPage < this.TotalPage - 1 ? string.Format(PagingBaseUrl, this.CurrentPage + 2) : string.Empty; } }
        public string PrevPageLink { get { return this.HasPaging && !string.IsNullOrEmpty(PagingBaseUrl) && this.CurrentPage > 0 ? string.Format(PagingBaseUrl, this.CurrentPage) : string.Empty; } }
        public List<Post> Data { get; set; }

        public PagedList()
        {

        }
        public PagedList(List<Post> data, int totalItems, int currentPage, int pageItems)
        {
            this.Data = data;
            this.TotalItems = totalItems;
            this.PageItems = pageItems;
            this.CurrentPage = currentPage;
            this.TotalPage = totalItems / pageItems;
            this.TotalPage = totalItems % pageItems == 0 ? this.TotalPage : (this.TotalPage + 1);
        }

        public PagedList<object> ToPagedListDynamic()
        {
            return this as PagedList<object>;
        }
    }

}
