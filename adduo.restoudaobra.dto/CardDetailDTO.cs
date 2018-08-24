using adduo.basetype.dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class CardDetailDTO : BaseDto
    {
        [JsonProperty("ad")]
        public AdDetailDTO Ad { get; set; }

        [JsonProperty("address")]
        public AddressDetailDTO Address { get; set; }

        [JsonProperty("owner")]
        public OwnerDetailDTO Owner { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        public CardDetailDTO()
        {
            Ad = new AdDetailDTO();
            Address = new AddressDetailDTO();
            Owner = new OwnerDetailDTO();
            Images = new List<string>();
        }
    }
}
