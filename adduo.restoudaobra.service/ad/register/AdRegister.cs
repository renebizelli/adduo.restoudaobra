using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.ad.register
{
    public class AdRegister
    {
        public bool Valid { get; set; }

        private IAdService adService { get; set; }
        private IAdImageService adImageService { get; set; }
        private IAddressService addressService { get; set; }

        public BaseRequest<CardRegisterDTO> request { get; set; }

        private int idOwner { get; set; }
        private int idAddress { get; set; }

        public AdRegister(
            IAdService adService,
            IAdImageService adImageService,
            IAddressService addressService)
        {

            this.adService = adService;
            this.adImageService = adImageService;
            this.addressService = addressService;
        }

        public void SetRequest(BaseRequest<CardRegisterDTO> request)
        {
            this.request = request;
        }

        public AdRegister Address()
        {
            Valid = false;

            if (request.Dto.Address.ActionType.Equals(ACTION_TYPE.NEW))
            {
                var req = new BaseRequest<AddressRegisterDTO>(request.Dto.Address);

                addressService.Validation(req);

                if (req.Success)
                {
                    var response = addressService.Save(req);

                    idAddress = response.Dto.id.Value;

                    Valid = true;
                }
            }
            else
            {
                request.Dto.Address.id.Reset();

                request.Dto.Address.id.Validate();

                if (request.Dto.Address.id.IsValid())
                {
                    idAddress = request.Dto.Address.id.Value;
                    Valid = true;
                }
            }

            return this;
        }

        public AdRegister Images()
        {
            var imageValidate = adImageService.Validation(request.Dto.Ad.Guid);

            request.Dto.Images.Status = PROPERTY_STATUS.VALID;

            if (!imageValidate) {
                request.Dto.Images.Status = PROPERTY_STATUS.INVALID;
            }

            if (Valid)
            {
                Valid = imageValidate;
            }

            return this;
        }

        public AdRegister Ad()
        {
            var req = new BaseRequest<AdRegisterDTO>(request.Dto.Ad);

            adService.Validation(req);

            Valid = req.Success;

            if (Valid)
            {
                request.Dto.Ad.idAddress = this.idAddress;
                request.Dto.Ad.Status = AD_STATUS.PUBLISHED;

                var response = adService.Save(req);

                Valid = response.Success;
            }

            return this;
        }

        public BaseResponse<CardRegisterDTO> Finally()
        {
            request.Success = Valid;

            return request.CreateResponse();
        }
    }
}
