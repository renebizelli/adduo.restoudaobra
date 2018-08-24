using adduo.basetype.dto;
using adduo.basetype.envelope;

namespace adduo.restoudaobra.ie.service
{
    public interface IDeleteService<TRequest>
        where TRequest : BaseDto
    {
        bool Delete(BaseRequest<TRequest> request);
    }
}
