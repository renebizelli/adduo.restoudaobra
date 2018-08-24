using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.service;
using adduo.restoudaobra.parser;
using System.Collections.Generic;
using System.Linq;

namespace adduo.restoudaobra.service.address
{
    public class AddressManager : BaseManager
    {
        public IAddressService addressService { get; set; }

        public int idOwner { get; set; }

        public AddressManager(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        public void SetOwner(int idOwner)
        {
            this.idOwner = idOwner;
        }

        public List<AddressRegisterDTO> ListAddressDTO()
        {
            var filter = new AddressFilter()
            {
                idOwner = this.idOwner
            };

            var parser = new AddressRegisterDTOParser();
            addressService.List(filter, parser);
            return parser.List()
                        .Cast<AddressRegisterDTO>()
                        .ToList();
        }

        public List<AddressDetailDTO> ListAdDetailAddressDTO()
        {
            var filter = new AddressFilter()
            {
                idOwner = this.idOwner
            };

            var parser = new AddressDetailDTOParser();
            addressService.List(filter, parser);
            return parser.List()
                        .Cast<AddressDetailDTO>()
                        .OrderBy(o => o.District)
                        .ToList();
        }

        public AddressRegisterDTO GetAddressDTO()
        {
            var filter = new AddressFilter()
            {
                idOwner = this.idOwner
            };

            var parser = new AddressRegisterDTOParser();
            addressService.Get(filter, parser);
            return (AddressRegisterDTO)parser.Get();
        }

        public AddressDetailDTO GetAdDetailAddressDTO()
        {
            var filter = new AddressFilter()
            {
                idOwner = this.idOwner
            };

            var parser = new AddressDetailDTOParser();
            addressService.Get(filter, parser);
            return (AddressDetailDTO)parser.Get();
        }

        public BaseResponse<AddressRegisterDTO> Save(BaseRequest<AddressRegisterDTO> request)
        {
            return addressService.Save(request);
        }
    }
}
