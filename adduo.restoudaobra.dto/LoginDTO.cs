using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class LoginDTO : BaseDto
    {
        [JsonProperty("email")]
        public PropertyDtoEmail Email { get; set; }
        [JsonProperty("password")]
        public PropertyDtoPassword Password { get; set; }

        [JsonProperty("name")]
        public PropertyDtoString Name { get; set; }
    }
}
