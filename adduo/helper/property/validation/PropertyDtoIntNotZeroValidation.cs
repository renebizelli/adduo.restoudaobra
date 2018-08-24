using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoIntNotZeroValidation : PropertyDtoBaseValidation<int>, IPropertyDtoValidation<int>
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
