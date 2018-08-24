using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class RedefinePasswordSolicitationDTO : BaseDto
    {
        [JsonProperty("cpfemail")]
        public PropertyDtoString CpfEmail { get; set; }

        [JsonProperty("ofuscated")]
        public string EmailOfuscated { get; set; }

        [JsonIgnore]
        public string CPF { get; set; }

        [JsonIgnore]
        public string Email { get; set; }

        [JsonIgnore]
        public string key { get; set; }

        [JsonIgnore]
        public int id { get; set; }

        public RedefinePasswordSolicitationDTO()
        {
            CpfEmail = new PropertyDtoString(128);

            AddPropertyToValidation(CpfEmail);
        }

    }
}
