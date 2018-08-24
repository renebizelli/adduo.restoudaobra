using adduo.basetype.dto;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class OwnerDetailDTO : BaseDto
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cellphone")]
        public string CellPhone { get; set; }
    }
}