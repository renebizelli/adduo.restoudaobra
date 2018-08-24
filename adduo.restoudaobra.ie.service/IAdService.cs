using adduo.basetype.envelope;
using adduo.restoudaobra.dto;

namespace adduo.restoudaobra.ie.service
{
    public interface IAdService :
        ISaveService<AdRegisterDTO, AdRegisterDTO>,
        IValidationNew<AdRegisterDTO>
    {
        void ChangeStatus(BaseRequest<AdChangeStatusDTO> request);
    }
}
