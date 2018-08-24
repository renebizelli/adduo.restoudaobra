using adduo.basetype.envelope;
using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.service
{
    public interface IOwnerResetPasswordService
    {
        BaseResponse<RedefinePasswordChangeDTO> Change(BaseRequest<RedefinePasswordChangeDTO> request);
        BaseResponse<RedefinePasswordSolicitationDTO> Solicitation(BaseRequest<RedefinePasswordSolicitationDTO> request);
    }
}
