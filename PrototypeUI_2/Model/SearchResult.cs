using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeUI_2.Model
{
    public class SearchResult
    {

    }

    public class PagedSearchResult<T>
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}
