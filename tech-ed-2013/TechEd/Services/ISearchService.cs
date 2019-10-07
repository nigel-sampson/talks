using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechEd.Services
{
    public interface ISearchService
    {
        Task<IList<SearchResult>> SearchAsync(string term);

        SearchResult GetResult(string itemLink);
    }
}
