using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplBlog.ViewModels
{
    public class QueryParams
    {
        public int CurrentPage { get; set; } 
        public int PageItems { get; set; }
        public string OrderByString { get; set; }
        public bool IsGetNRowsOnGroup { get; set; }
        public bool IgnogrePaging { get; set; }
        public QueryParams()
        {
            CurrentPage = 0;
            PageItems = int.MaxValue;
        }
    }
}
