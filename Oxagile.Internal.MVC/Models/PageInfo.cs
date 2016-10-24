using System;

namespace Oxagile.Internal.MVC.Models
{public class PageInfo
    {
        public int PageNumber { get; set; } // number of current page
        public int PageSize { get; set; } // items per page
        public int TotalItems { get; set; } // total items
        public int TotalPages  // total pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}