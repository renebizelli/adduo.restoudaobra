using adduo.basetype.dto;
using adduo.methodextension;
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

        [JsonProperty("phoneFormat")]
        public string PhoneFormat { get { return Phone.PhoneFormat(); } }

        [JsonProperty("cellphone")]
        public string CellPhone { get; set; }


        [JsonProperty("cellphoneFormat")]
        public string CellPoneFormat { get { return CellPhone.PhoneFormat(); } }

    }
}