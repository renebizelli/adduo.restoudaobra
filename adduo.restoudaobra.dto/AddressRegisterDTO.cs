using adduo.basetype.dto;
using adduo.helper.property;
using adduo.restoudaobra.constants;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AddressRegisterDTO : BaseDto
    {
        [JsonProperty("id")]
        public PropertyDtoInt id { get; set; }

        [JsonProperty("state")]
        public PropertyDtoItem State { get; set; }

        [JsonProperty("city")]
        public PropertyDtoString City { get; set; }

        [JsonProperty("district")]
        public PropertyDtoString District { get; set; }

        [JsonProperty("actionType")]
        public ACTION_TYPE ActionType { get; set; }

        [JsonIgnore]
        public int idOwner { get; set; }

        public AddressRegisterDTO()
        {
            id = new PropertyDtoInt();
            State = new PropertyDtoItem();
            City = new PropertyDtoString(128);
            District = new PropertyDtoString(128);

            AddPropertyToValidation(State);
            AddPropertyToValidation(City);
            AddPropertyToValidation(District);
        }

    }
}
