using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElasticSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElasticSearchController : ControllerBase
    {
        private readonly ILogger<ElasticSearchController> _logger;

        public ElasticSearchController(ILogger<ElasticSearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<SearchResult> GetItemsAsync()
        {
            var indexName = "content-title-aa";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200/"))
                                             .DefaultIndex(indexName);
            var client = new ElasticClient(settings);

            var result = await client.SearchAsync<ItemDTO>(s => s.AllIndices().From(0).Size(1000)
                .Query(q => q.Match(m => m.Field(f => f.Sexes).Query("f")))
                .Aggregations(p => p.Terms("sex_aggregation", g => g.Field(i => i.Sexes))));

            return new SearchResult(){ ResultSet = result.Documents, Aggregations = result.Aggregations[$"sex_aggregation"] };
        }
    }
}
