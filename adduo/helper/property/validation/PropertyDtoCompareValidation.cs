





namespace adduo.helper.property.validation
{
    public class PropertyDtoCompareValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        private PropertyDto<string> propertyCompare { get; set; }

        public PropertyDtoCompareValidation(PropertyDto<string> property)
        {
            propertyCompare = property;
        }

        public void Validate()
        {
            if (CanValidate())
            {
                var test = propertyCompare.Value.Equals(property.Value);
                SetStatus(test, ERROR_CODE.DIFFERENT, propertyCompare);
                SetStatus(test, ERROR_CODE.NONE, property);
            }
        }
    }
}
