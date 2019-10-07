using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TechEd.Services
{
    public class Channel9SearchService : TechEd.Services.ISearchService
    {
        private readonly HttpClient httpClient;
        private readonly List<SearchResult> cachedResults = new List<SearchResult>();

        public Channel9SearchService()
        {
            var gzipHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };

            httpClient = new HttpClient(gzipHandler)
            {
                BaseAddress = new Uri("http://channel9.msdn.com", UriKind.Absolute)
            };
        }

        public async Task<IList<SearchResult>> SearchAsync(string term)
        {
            var uri = String.Format("/api/search?term={0}", WebUtility.UrlEncode(term));
            
            var response = await httpClient.GetAsync(uri);

            var json = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<IList<SearchResult>>(json);

            cachedResults.AddRange(results);

            return results;
        }

        public SearchResult GetResult(string itemLink)
        {
            return cachedResults.FirstOrDefault(r => r.ItemLink == itemLink);
        }
    }
}
