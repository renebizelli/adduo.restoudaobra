using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.parser;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.address
{
    public class AddressService : BaseService, IAddressService
    {
        private IAddressDAL addressDAL { get; set; }

        public AddressService(IAddressDAL addressDAL) 
        {
            this.addressDAL = addressDAL;
        }

        public BaseResponse<AddressRegisterDTO> Save(BaseRequest<AddressRegisterDTO> request)
        {
            if (request.Success)
            {
                addressDAL.Save(request.Dto);
            }

            return request.CreateResponse();
        }

        public void Validation(BaseRequest<AddressRegisterDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            foreach (var propertyDto in request.Dto.Properties)
            {
                propertyDto.Validate();
            }

            request.Success = PropertyHelper.ReturnTrueIfAllValid(request.Dto);
        }

        public void List(AddressFilter filter, IParser parser)
        {
            addressDAL.List(filter, parser);
        }

        public void Get(AddressFilter filter, IParser parser)
        {
            addressDAL.Get(filter, parser);
        }
    }
}
