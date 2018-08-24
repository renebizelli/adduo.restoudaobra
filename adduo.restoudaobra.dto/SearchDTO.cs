using adduo.basetype.dto;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class SearchDTO : BaseDto
    {
        [JsonProperty("term")]
        public string Term { get; set; }
    }
}
