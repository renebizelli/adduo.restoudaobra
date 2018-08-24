using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class TokenDTO
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
