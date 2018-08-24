using adduo.basetype.dto;
using System;
using System.Linq;

namespace adduo.helper.property
{
    public class PropertyHelper
    {
        public static PROPERTY_STATUS ReturnInvalidIfTrue(bool condition)
        {
            return condition ? PROPERTY_STATUS.INVALID : PROPERTY_STATUS.VALID;
        }
        public static PROPERTY_STATUS ReturnValidIfTrue(bool condition)
        {
            return condition ? PROPERTY_STATUS.VALID : PROPERTY_STATUS.INVALID;
        }

        public static bool ReturnTrueIfValid(PropertyDto property)
        {
            return property.Status == PROPERTY_STATUS.VALID;
        }

        public static bool ReturnTrueIfAllValid(BaseDto dto)
        {
            return dto.Properties.All(a => a.Status == PROPERTY_STATUS.VALID);
        }

        public static bool ReturnTrueIfAnyValid(BaseDto dto)
        {
            return dto.Properties.Any(a => a.Status == PROPERTY_STATUS.VALID);
        }

        public static bool ReturnFalseIfAnyInvalid(BaseDto dto)
        {
            return !dto.Properties.Any(a => a.Status == PROPERTY_STATUS.INVALID);
        }

        public static void ResetProperty(BaseDto dto)
        {
            foreach (var prop in dto.Properties)
            {
                prop.Reset();
            }
        }

        [Obsolete("trocat por dto", true)]
        public static void ResetProperty(params PropertyDto[] properties)
        {
            foreach (var prop in properties)
            {
                prop.Reset();
            }
        }

        [Obsolete("trocat por dto", true)]
        public static bool ReturnFalseIfAnyInvalid(params PropertyDto[] properties)
        {
            return !properties.Any(a => a.Status == PROPERTY_STATUS.INVALID);
        }

        [Obsolete("trocat por dto", true)]
        public static bool ReturnTrueIfAnyValid(params PropertyDto[] properties)
        {
            return properties.Any(a => a.Status == PROPERTY_STATUS.VALID);
        }

        [Obsolete("trocat por dto", true)]
        public static bool ReturnTrueIfAllValid(params PropertyDto[] properties)
        {
            return properties.All(a => a.Status == PROPERTY_STATUS.VALID);
        }
    }
}
