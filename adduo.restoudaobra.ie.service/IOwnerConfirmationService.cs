using adduo.basetype.envelope;
using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.service
{
    public interface IOwnerConfirmationService
    {
        BaseResponse<OwnerDTO> Confirmation(BaseRequest<OwnerConfirmationDTO> request);
        void SendEmail(OwnerDTO dto);
        void SendEmail(OwnerResendDTO dto);
    }
}
