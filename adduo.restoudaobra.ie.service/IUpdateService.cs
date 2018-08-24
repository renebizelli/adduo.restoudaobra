using adduo.basetype.dto;
using adduo.basetype.envelope;

namespace adduo.restoudaobra.ie.service
{
    public interface IUpdateService<TRequest, TResponse>
        where TRequest : BaseDto
        where TResponse : BaseDto
    {
        BaseResponse<TResponse> Update(BaseRequest<TRequest> request);
    }

    public interface IUpdateService<T> : IUpdateService<T, T>
        where T : BaseDto
    {
    }

}
