using adduo.helper.validation;

namespace adduo.helper.property.validation
{
    public class PropertyDtoPhoneValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = PhoneValidation.Test(property.Value);
                SetStatus(test, ERROR_CODE.INVALID);
            }
        }
    }
}
