using adduo.basetype.dto;
using adduo.basetype.envelope;

namespace adduo.restoudaobra.ie.service
{
    public interface IValidationNew<TDtoRequest> 
        where TDtoRequest : BaseDto
    {
        void Validation(BaseRequest<TDtoRequest> request);
    }
}
