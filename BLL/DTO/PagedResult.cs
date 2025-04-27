using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }

        public PagedResult(IEnumerable<T> items, int totalCount, int currentPage)
        {
            Items = items;
            TotalCount = totalCount;
            CurrentPage = currentPage;
        }

        
    }
}
