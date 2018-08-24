using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("owner/confirmation")]
    public class OwnerConfirmationController : BaseApiController
    {
        private OwnerManager ownerManager { get; set; }

        public OwnerConfirmationController(OwnerManager ownerManager)
        {
            this.ownerManager = ownerManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public ObjectResult Post([FromBody] BaseRequest<OwnerConfirmationDTO> request)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            try
            {
                response = ownerManager.Confirmation(request);

                response.ThrownIfError();

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
