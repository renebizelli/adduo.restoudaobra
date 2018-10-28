using adduo.basetype.dto;
using adduo.helper.property;
using adduo.restoudaobra.constants;
using Newtonsoft.Json;
using System;

namespace adduo.restoudaobra.dto
{
    [JsonObject]
    public class AdRegisterDTO : BaseDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("name")]
        public PropertyDtoString Name { get; set; }

        [JsonProperty("option")]
        public PropertyDtoString Option { get; set; }

        [JsonProperty("brand")]
        public PropertyDtoString Brand { get; set; }

        [JsonProperty("quantity")]
        public PropertyDtoString Quantity { get; set; }

        [JsonProperty("type")]
        public AD_TYPE Type { get; set; }

        [JsonProperty("price")]
        public PropertyDtoDecimal Price { get; set; }

        [JsonProperty("status")]
        public AD_STATUS Status { get; set; }

        [JsonProperty("statusname")]
        public string StatusName { get; set; }

        [JsonIgnore]
        public int idOwner { get; set; }

        [JsonProperty("idaddress")]
        public int idAddress { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("viewcontact")]
        public int ViewContact { get; set; }


        public AdRegisterDTO()
        {
            Guid = Guid.Empty;
            Name = new PropertyDtoString(128);
            Option = new PropertyDtoString(255);
            Brand = new PropertyDtoString(32);
            Quantity = new PropertyDtoString(32);
            Price = new PropertyDtoDecimal();
            Type = AD_TYPE.NONE;
            Status = AD_STATUS.NONE;
            Created = DateTime.MinValue;

            AddPropertyToValidation(Name);
            AddPropertyToValidation(Option);
            AddPropertyToValidation(Brand);
            AddPropertyToValidation(Quantity);
        }
    }
}