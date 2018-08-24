using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    public class RedefinePasswordController : AuthenticatedController
    {
        private OwnerManager ownerManager { get; set; }

        public RedefinePasswordController(
            OwnerManager ownerManager,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.ownerManager = ownerManager;
        }


        [HttpPost]
        [Route("redefinepassword")]
        [AllowAnonymous]
        public ObjectResult Post([FromBody] BaseRequest<RedefinePasswordSolicitationDTO> request)
        {
            BaseResponse<RedefinePasswordSolicitationDTO> response = null;

            try
            {
                response = ownerManager.Solicitation(request);

                response.ThrownIfError();

                base.PrepareResult<BaseResponse<RedefinePasswordSolicitationDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<RedefinePasswordSolicitationDTO>>(response);
            }

            return base.result;
        }

        [HttpPut]
        [Route("redefinepassword")]
        public ObjectResult Put([FromBody] BaseRequest<RedefinePasswordChangeDTO> request)
        {
            BaseResponse<RedefinePasswordChangeDTO> response = null;

            try
            {
                request.Dto.id = base.GetOwner();

                response = ownerManager.Change(request);

                response.ThrownIfError();

                base.PrepareResult<BaseResponse<RedefinePasswordChangeDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<RedefinePasswordChangeDTO>>(response);
            }

            return base.result;
        }


        [HttpGet("key", Name = "Get")]
        [Route("redefinepassword")]
        [AllowAnonymous]
        public ObjectResult Get(Guid key)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            try
            {
                if (key == null || key == Guid.Empty)
                {
                    throw new Exception();
                }

                response = ownerManager.Login(key);

                base.PrepareResult<BaseResponse<OwnerAuthenticatedDTO>>(response);

            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<OwnerAuthenticatedDTO>>(response);
            }

            return base.result;
        }


    }
}
