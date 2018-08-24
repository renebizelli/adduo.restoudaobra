

using Newtonsoft.Json;

namespace adduo.basetype.dto
{
    [JsonObject]
    public class ItemDTO : BaseDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
