namespace adduo.helper.property
{
    public interface IPropertyDtoValidation<T>
    {

        void Set(IPropertyDto<T> property);
        void Validate();
    }
}
