using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoSQLInjectionValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = !property.Value.SQLInjection();

                SetStatus(test, ERROR_CODE.INVALID);
            }
        }
    }
}
