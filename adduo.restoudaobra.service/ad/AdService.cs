using adduo.basetype.envelope;
using adduo.helper.property;
using adduo.restoudaobra.constants;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.dal;
using adduo.restoudaobra.ie.service;

namespace adduo.restoudaobra.service.ad
{
    public class AdService : BaseService, IAdService
    {
        private IAdDAL productDAL { get; set; }

        public AdService(IAdDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public BaseResponse<AdRegisterDTO> Save(BaseRequest<AdRegisterDTO> request)
        {
            if (request.Success)
            {
                productDAL.Save(request.Dto);
            }

            return request.CreateResponse();
        }

        public void ChangeStatus(BaseRequest<AdChangeStatusDTO> request)
        {
            var dto = request.Dto;

            productDAL.ChangeStatus(dto);

        }

        public void Validation(BaseRequest<AdRegisterDTO> request)
        {
            PropertyHelper.ResetProperty(request.Dto);

            if (request.Dto.Type == AD_TYPE.SALE)
            {
                request.Dto.AddPropertyToValidation(request.Dto.Price);
            }

            foreach (var property in request.Dto.Properties)
            {
                property.Validate();
            }


            request.Success = PropertyHelper.ReturnTrueIfAllValid(request.Dto);
        }

    }
}
