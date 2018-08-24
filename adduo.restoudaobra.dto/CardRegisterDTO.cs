using adduo.basetype.dto;
using adduo.helper.property;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class CardRegisterDTO : BaseDto
    {
        [JsonProperty("ad")]
        public AdRegisterDTO Ad { get; set; }

        [JsonProperty("address")]
        public AddressRegisterDTO Address { get; set; }

        [JsonProperty("images")]
        public PropertyListDto<AdImageDTO> Images { get; set; }

        [JsonProperty("initial")]
        public AdRegisterInitialDTO Initial { get; set; }

        public CardRegisterDTO()
        {
            Ad = new AdRegisterDTO();
            Address = new AddressRegisterDTO();
            Images = new PropertyListDto<AdImageDTO>();

            Initial = new AdRegisterInitialDTO();
        }
    }
}
