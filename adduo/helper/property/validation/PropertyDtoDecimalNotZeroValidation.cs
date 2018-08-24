
using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoDecimalNotZeroValidation : PropertyDtoBaseValidation<decimal>, IPropertyDtoValidation<decimal>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = property.Value.NotZero();

                SetStatus(test, ERROR_CODE.EMPTY);
            }
        }
    }
}
