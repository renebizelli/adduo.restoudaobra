namespace adduo.restoudaobra.ie.service
{
    public interface IValidation<TRequest, TResponse>
    {
        void Validation(TRequest request, TResponse response);
    }
}
