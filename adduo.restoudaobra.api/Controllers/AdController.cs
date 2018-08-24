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
    [Route("ad")]
    public class AdController : AuthenticatedController
    {
        public AdManager adManager { get; set; }
        public AddressManager addressManager { get; set; }


        public AdController(
            AdManager adManager,
            AddressManager addressManager,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.adManager = adManager;
            this.addressManager = addressManager;

            var idOwner = GetOwner();
            this.adManager.SetOwner(idOwner);
            this.addressManager.SetOwner(idOwner);
        }

        [HttpGet()]
        [Route("{guid}")]
        public ObjectResult Get(Guid guid)
        {
            var dto = new CardRegisterDTO();

            var response = new BaseResponse<CardRegisterDTO>(dto);

            try
            {
                if (guid.Equals(Guid.Empty))
                {
                    base.PrepareNotFoundResult();
                }
                else
                {
                    var idOwner = base.GetOwner();

                    dto = adManager.Get(guid);

                    dto.Initial = new AdRegisterInitialDTO()
                    {
                        Guid = guid,
                        Addresses = addressManager.ListAdDetailAddressDTO()
                    };

                    response.Dto = dto;
                    response.Success = true;

                    base.PrepareResult<BaseResponse<CardRegisterDTO>>(response);
                }
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardRegisterDTO>>(response);
            }

            return base.result;
        }

        [HttpPost]
        public ObjectResult Post([FromBody] BaseRequest<CardRegisterDTO> request)
        {
            var response = new BaseResponse<CardRegisterDTO>(request.Dto);

            try
            {
                response = adManager.Save(request);

                response.ThrownIfError();

                base.PrepareResult<BaseResponse<CardRegisterDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardRegisterDTO>>(response);
            }

            return base.result;
        }

        [HttpPut]
        public ObjectResult Put([FromBody] BaseRequest<CardRegisterDTO> request)
        {
            var response = new BaseResponse<CardRegisterDTO>(request.Dto);

            try
            {
                response = adManager.Save(request);

                response.ThrownIfError();

                base.PrepareResult<BaseResponse<CardRegisterDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardRegisterDTO>>(response);
            }

            return base.result;
        }
    }
}
