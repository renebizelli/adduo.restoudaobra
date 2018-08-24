using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.dal
{
    public interface IAdDAL : 
        ISaveDAL<AdRegisterDTO>
    {
        void ChangeStatus(AdChangeStatusDTO dto);
    }
}
