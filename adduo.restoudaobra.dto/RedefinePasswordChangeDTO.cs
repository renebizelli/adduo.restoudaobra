using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class RedefinePasswordChangeDTO : BaseDto
    {
        [JsonProperty("password")]
        public PropertyDtoPassword Password { get; set; }

        [JsonProperty("confirmation")]
        public PropertyDtoPassword Confirmation { get; set; }

        [JsonIgnore]
        public int id { get; set; }

        public RedefinePasswordChangeDTO()
        {
            Password = new PropertyDtoPassword();
            Confirmation = new PropertyDtoPassword();

            AddPropertyToValidation(Password);
            AddPropertyToValidation(Confirmation);
        }
    }
}
