using adduo.basetype.dto;
using Newtonsoft.Json;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class CardSearchDTO: BaseDto
    {
        [JsonProperty("ad")]
        public AdDetailDTO Ad { get; set; }

        [JsonProperty("address")]
        public AddressDetailDTO Address { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        public CardSearchDTO()
        {
            Ad = new AdDetailDTO();
            Address = new AddressDetailDTO();
        }

    }
}
