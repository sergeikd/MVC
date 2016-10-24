using System.Collections.Generic;
using System.Linq;

namespace Oxagile.Internal.MVC.DALCF
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        //TODO[10/14/2016 VZ]: Why have you decided to use nullable int for page here?
        public PagedList(IQueryable<T> source, int? page, int pageSize)
        {
            if(source == null) return;
            page = page ?? 1;
            Page = (int) (page < 1 ? 1 : page);
            TotalCount = source.Count();
            PageSize = pageSize;
            AddRange(source.Skip((Page - 1) * PageSize).Take(PageSize));
        }
    }
}