using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.helper.property
{

    [JsonObject]
    public class PropertyListDto<T> : PropertyDto
    {
        [JsonProperty("list")]
        public List<T> List { get; set; }

        [JsonProperty("listdefault")]
        public List<T> ListDefault { get; set; }

        public PropertyListDto()
        {
            List = new List<T>();
            ListDefault = new List<T>();
        }
    }
}
