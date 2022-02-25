using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models.Paging
{
    public class PagingQueryParams
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Sort { get; set; }

        public SortingDirection? SortingDirection { get; set; }
    }

    public enum SortingDirection
    {
        ASC=1,
        DESC
    }
}
