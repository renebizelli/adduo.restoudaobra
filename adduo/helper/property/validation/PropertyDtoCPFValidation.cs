using adduo.helper.validation;






namespace adduo.helper.property.validation
{
    public class PropertyDtoCPFValidation : PropertyDtoBaseValidation<string>, IPropertyDtoValidation<string>
    {
        public void Validate()
        {
            if (CanValidate())
            {
                var test = CPFValidation.Test(property.Value);

                SetStatus(test, ERROR_CODE.INVALID);
            }
        }
    }
}
