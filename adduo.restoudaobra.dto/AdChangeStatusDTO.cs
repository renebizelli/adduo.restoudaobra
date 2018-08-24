using adduo.basetype.dto;
using adduo.restoudaobra.constants;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AdChangeStatusDTO : BaseDto
    {
        [JsonProperty("guid")]
        public Guid guid { get; set; }

        [JsonProperty("status")]
        public AD_STATUS Status { get; set; }

        [JsonIgnore]
        public int idOwner { get; set; }
    }
}
