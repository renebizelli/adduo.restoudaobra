using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoNotEmptyValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = property.Value.NotIsNullOrEmpty();

                SetStatus(test, ERROR_CODE.EMPTY);
            }
        }
    }
}
