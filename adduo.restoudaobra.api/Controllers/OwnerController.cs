using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers

{
    [Route("owner")]
    public class OwnerController : AuthenticatedController
    {
        private OwnerManager ownerManager { get; set; }

        public OwnerController(
            OwnerManager ownerManager,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.ownerManager = ownerManager;
        }

        #region AUTHORIZE

        [HttpGet]
        public ObjectResult Get()
        {
            var response = new BaseResponse<OwnerDTO>();

            try
            {
                var idOwner = GetOwner();

                var dto = ownerManager.Get(idOwner);

                response.Dto = dto;

                base.PrepareResult<BaseResponse<OwnerDTO>>(response);
            }
            catch (ArgumentNullException nex)
            {
                base.PrepareUnauthorizedResult();
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<OwnerDTO>>(response);
            }

            return base.result;

        }

        [HttpPut]
        public ObjectResult Put([FromBody] BaseRequest<OwnerUpdateDTO> request)
        {
            var response = new BaseResponse<OwnerUpdateDTO>();

            try
            {
                request.Dto.id = base.GetOwner();

                response = ownerManager.Update(request);

                response.ThrownIfError();

                base.PrepareResult<BaseResponse<OwnerUpdateDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<OwnerUpdateDTO>>(response);
            }

            return base.result;
        }

        #endregion

        #region AllowAnonymous

        [HttpPost]
        [AllowAnonymous]
        public ObjectResult Post([FromBody] BaseRequest<OwnerRegisterDTO> request)
        {
            var response = new BaseResponse<OwnerRegisterDTO>(request.Dto);

            try
            {
                response = ownerManager.Save(request);
                response.ThrownIfError();

                base.PrepareResult<BaseResponse<OwnerRegisterDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<OwnerRegisterDTO>>(response);
            }

            return base.result;
        }

        #endregion

    }
}
