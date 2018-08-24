using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.dto.filter;
using adduo.restoudaobra.service.ad;
using adduo.restoudaobra.service.address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("initialad")]
    public class AdInitialController : AuthenticatedController
    {
        public AddressManager addressManager { get; set; }

        public AdInitialController(
            AddressManager addressManager,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.addressManager = addressManager;

            var idOwner = GetOwner();
            this.addressManager.SetOwner(idOwner);
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var dto = new AdRegisterInitialDTO
            {
                Guid = Guid.NewGuid()
            };

            dto.Addresses = addressManager.ListAdDetailAddressDTO();

            var response = new BaseResponse<AdRegisterInitialDTO>(dto);

            base.PrepareResult<BaseResponse<AdRegisterInitialDTO>>(response);

            return base.result;
        }
    }

}
