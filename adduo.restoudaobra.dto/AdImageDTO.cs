using adduo.basetype.dto;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AdImageDTO : BaseDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("guidProduct")]
        public Guid GuidProduct { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonIgnore]
        public int idOwner { get; set; }

        [JsonIgnore]
        public DateTime CreateAt { get; set; }
    }
}
