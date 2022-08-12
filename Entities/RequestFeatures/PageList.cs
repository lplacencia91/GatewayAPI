using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.RequestFeatures
{
    public class PageList<T> : List<T>
    {
        public MetaData metaData { get; set; }
        public PageList(List<T> items, int count, int pagenumber, int pagesize)
        {
            metaData = new MetaData
            {
                CurrentPage = pagenumber,
                PageSize = pagesize,
                TotalCount = count,
                TotalPage = (int)Math.Ceiling(count / (double)pagesize)

            };
            AddRange(items);

        }
        public static PageList<T> ToPageList(IEnumerable<T> source, int pagenumber, int pagesize)
        {
            var count = source.Count();
            var items = source.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();
            return new PageList<T>(items, count, pagenumber, pagesize);
        }


    }
}
