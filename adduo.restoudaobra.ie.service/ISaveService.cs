using adduo.basetype.dto;
using adduo.basetype.envelope;

namespace adduo.restoudaobra.ie.service
{
    public interface ISaveService<TRequest, TResponse> 
        where TRequest : BaseDto
        where TResponse : BaseDto
    {
        BaseResponse<TResponse> Save(BaseRequest<TRequest> request);
    }


    public interface ISaveService<T> : ISaveService<T, T>
    where T : BaseDto
    {
    }


}
