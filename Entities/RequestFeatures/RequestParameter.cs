using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameter
    {
        const int maxPageSize = 50;
        public int pageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize ? maxPageSize : value); }
        }
    }
}
