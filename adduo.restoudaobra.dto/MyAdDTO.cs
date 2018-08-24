using adduo.basetype.dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class MyAdDTO : BaseDto
    {
        [JsonProperty("cards")]
        public List<CardDetailDTO> Cards { get; set; }

        [JsonProperty("status")]
        public List<ItemDTO> Status { get; set; }

        public MyAdDTO()
        {
            Status = new List<ItemDTO>();
            Cards = new List<CardDetailDTO>();
        }
    }
}
