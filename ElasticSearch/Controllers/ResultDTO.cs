using System.Collections.Generic;
using Nest;

namespace ElasticSearch.Controllers
{
    public class SearchResult
    {
        public IEnumerable<object> ResultSet { get; set; }
        public AggregateDictionary Aggregations { get; set; }
    }
}