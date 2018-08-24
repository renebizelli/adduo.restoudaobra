using adduo.basetype.dto;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class OwnerConfirmationDTO : BaseDto
    {
        [JsonProperty("guid")]
        public Guid Guid { get; set; }
    }
}
