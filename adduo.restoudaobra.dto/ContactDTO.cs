using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class ContactDTO : BaseDto
    {
        [JsonProperty("name")]
        public PropertyDtoString Name { get; set; }

        [JsonProperty("email")]
        public PropertyDtoEmail Email { get; set; }

        [JsonProperty("phone")]
        public PropertyDtoPhone Phone { get; set; }

        [JsonProperty("message")]
        public PropertyDtoText Message { get; set; }

        [JsonIgnore]
        public string EmailTo { get; set; }

        public ContactDTO()
        {

            Name = new PropertyDtoString(32);
            Email = new PropertyDtoEmail();
            Phone = new PropertyDtoPhone();
            Message = new PropertyDtoText();

            AddPropertyToValidation(Name);
            AddPropertyToValidation(Email);
            AddPropertyToValidation(Phone);
            AddPropertyToValidation(Message);
        }
    }
}
