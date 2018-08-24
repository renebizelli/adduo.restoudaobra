using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.dal
{
    public interface IRefefinePasswordDAL :
        ISaveDAL<RedefineResetPasswordDTO>,
        IDeleteDAL<OwnerFilter>

    {
        void ChangePassword(RedefinePasswordChangeDTO changePasswordDTO);
    }
}
