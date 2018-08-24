using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class OwnerResendDTO : BaseDto
    {
        [JsonProperty("email")]
        public PropertyDtoString Email { get; set; }
    }
}
