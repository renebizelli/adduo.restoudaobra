namespace adduo.helper.property.validation
{
    public class PropertyDtoBaseValidation<T>
    {
        public IPropertyDto<T> property { get; set; }

        public void Set(IPropertyDto<T> property)
        {
            this.property = property;
        }

        protected bool CanValidate()
        {
            return property.Status != PROPERTY_STATUS.INVALID;
        }

        protected void SetStatus(bool valid, ERROR_CODE error)
        {
            SetStatus(valid, error, property);
        }

        protected void SetStatus(bool valid, ERROR_CODE error, IPropertyDto<T> targetProperty)
        {
            targetProperty.Status = valid ? PROPERTY_STATUS.VALID : PROPERTY_STATUS.INVALID;

            if (!valid)
            {
                targetProperty.Code = error;
            }
        }
    }

}
