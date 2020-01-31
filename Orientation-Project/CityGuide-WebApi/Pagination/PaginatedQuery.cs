using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Pagination
{
    public class PaginatedQuery
    {
        public PaginatedQuery()
        {
            PageNumber = 1;
            PageSize = 3;
        }

        public PaginatedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
