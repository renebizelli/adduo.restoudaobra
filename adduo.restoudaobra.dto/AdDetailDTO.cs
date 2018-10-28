using adduo.basetype.dto;
using adduo.restoudaobra.constants;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AdDetailDTO : BaseDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("option")]
        public string Option { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("type")]
        public AD_TYPE Type { get; set; }

        [JsonProperty("status")]
        public AD_STATUS Status { get; set; }

        [JsonProperty("statusname")]
        public string StatusName { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("viewcontact")]
        public int ViewContact { get; set; }


    }
}