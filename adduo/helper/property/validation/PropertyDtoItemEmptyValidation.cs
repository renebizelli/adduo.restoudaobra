using adduo.basetype.dto;
using adduo.methodextension;

namespace adduo.helper.property.validation
{
    public class PropertyDtoItemEmptyValidation : PropertyDtoBaseValidation<ItemDTO>, IPropertyDtoValidation<ItemDTO>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = property.Value.id.NotZero() || property.Value.Name.NotIsNullOrEmpty();

                SetStatus(test, ERROR_CODE.EMPTY);
            }
        }
    }
}
