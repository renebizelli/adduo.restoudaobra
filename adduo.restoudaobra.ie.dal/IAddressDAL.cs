using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;

namespace adduo.restoudaobra.ie.dal
{
    public interface IAddressDAL :
        ISaveDAL<AddressRegisterDTO>, 
        IGetDAL<AddressFilter>,
        IListDAL<AddressFilter>
    {
    }
}
