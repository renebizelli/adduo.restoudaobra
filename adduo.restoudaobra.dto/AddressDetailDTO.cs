using adduo.basetype.dto;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AddressDetailDTO : BaseDto
    {
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonIgnore]
        public int idOwner { get; set; }
    }
}