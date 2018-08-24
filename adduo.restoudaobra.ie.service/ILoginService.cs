using adduo.basetype.envelope;
using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.service
{
    public interface ILoginService
    {
        BaseResponse<OwnerAuthenticatedDTO> Login(OwnerDTO dto);
    }
}
