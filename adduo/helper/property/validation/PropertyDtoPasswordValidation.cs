using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoPasswordValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var propertyPassword = (PropertyDtoPassword)property;
                var test = propertyPassword.Value.NotIsNullOrEmpty();
                SetStatus(test, ERROR_CODE.EMPTY);
            }
        }
    }
}
