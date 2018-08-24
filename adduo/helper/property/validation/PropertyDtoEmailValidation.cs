using adduo.helper.validation;

namespace adduo.helper.property.validation
{
    public class PropertyDtoEmailValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = EmailValidation.Test(property.Value);
                SetStatus(test, ERROR_CODE.INVALID);
            }
        }
    }
}
