using adduo.basetype.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AdRegisterInitialDTO : BaseDto
    {
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("addresses")]
        public List<AddressDetailDTO> Addresses { get; set; }
    }
}
