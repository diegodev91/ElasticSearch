using System.Collections;
using System.Collections.Generic;

namespace ElasticSearch.Controllers
{
    public class ItemDTO
    {
        public string ContentObjectType { get; set; }
        public List<int> CollectionIds { get; set; }
        public List<string> Sexes { get; set; }
        public string ContentId { get; set; }
        public long ContentTypeId { get; set; }
        public List<int> LicensesIds { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string RxNromCodes { get; set; }
    }
}