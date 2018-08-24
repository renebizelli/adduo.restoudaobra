using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.owner;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("owner/resend")]
    public class OwnerResendController : BaseApiController
    {
        private OwnerManager ownerManager { get; set; }

        public OwnerResendController(OwnerManager ownerManager)
        {
            this.ownerManager = ownerManager;
        }

        [HttpPost]
        [Route("owner/resend")]
        public ObjectResult Post(BaseRequest<OwnerResendDTO> request)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            try
            {
                ownerManager.SendEmail(request.Dto);

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

