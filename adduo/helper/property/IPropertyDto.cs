namespace adduo.helper.property
{
    public interface IPropertyDto<T>
    {
        T Value { get; set;}
        PROPERTY_STATUS Status { get; set; }
        ERROR_CODE Code { get; set; }
    }
}
