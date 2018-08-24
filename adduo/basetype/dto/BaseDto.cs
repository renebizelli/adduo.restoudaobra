using adduo.helper.property;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace adduo.basetype.dto
{
    public abstract class BaseDto
    {
        [JsonIgnore]
        public List<PropertyDto> Properties { get; private set; }

        public BaseDto()
        {
            ResetPropertyToValidation();
        }

        public void AddPropertyToValidation(PropertyDto propertyDto)
        {
            Properties.Add(propertyDto);
        }

        public void ResetPropertyToValidation()
        {
            Properties = new List<PropertyDto>();
        }
    }
}
