using adduo.basetype.envelope;
using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.service
{
    public interface IContactService
    {
        BaseResponse<ContactDTO> Send(BaseRequest<ContactDTO> request);

    }
}
