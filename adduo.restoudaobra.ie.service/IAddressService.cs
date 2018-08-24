using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.service
{
    public interface IAddressService : 
        ISaveService<AddressRegisterDTO, AddressRegisterDTO>,
        IListService<AddressFilter>,
        IGetService<AddressFilter>,
        IValidationNew<AddressRegisterDTO>
    {
    }
}
