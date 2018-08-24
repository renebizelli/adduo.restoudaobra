using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.service.address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("Address")]
    public class AddressController : AuthenticatedController
    {
        private AddressManager addressManager { get; set; }

        public AddressController(
            AddressManager addressManager,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.addressManager = addressManager;

            var idOwner = base.GetOwner();
            this.addressManager.SetOwner(idOwner);
        }

        [HttpPost]
        public ObjectResult Post(BaseRequest<AddressRegisterDTO> request)
        {
            var response = new BaseResponse<AddressRegisterDTO>(request.Dto);

            try
            {
                request.Dto.idOwner = base.GetOwner();
                response = addressManager.Save(request);

                base.PrepareResult<BaseResponse<AddressRegisterDTO>>(response);

            }
            catch (Exception ex)
            {
                base.PrepareResult<BaseResponse<AddressRegisterDTO>>(response);
            }

            return base.result;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var response = new BaseResponse<AddressDetailDTO>();

            try
            {

                response.Dtos = addressManager.ListAdDetailAddressDTO();

                base.PrepareResult<BaseResponse<AddressDetailDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<AddressDetailDTO>>(response);
            }

            return base.result;
        }
    }
}
