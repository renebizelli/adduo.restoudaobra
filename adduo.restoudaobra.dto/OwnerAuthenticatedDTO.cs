using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class OwnerAuthenticatedDTO
    {
        [JsonProperty("token")]
        public TokenDTO Token { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public OwnerAuthenticatedDTO()
        {
        }
    }
}
