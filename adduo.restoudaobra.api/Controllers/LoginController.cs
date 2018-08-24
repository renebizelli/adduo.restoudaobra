using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.owner;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("login")]
    public class LoginController : BaseApiController
    {
        private OwnerManager ownerManager { get; set; }

        //public LoginController(
        //    IEmailService emailService,
        //    IConfiguration configuration,
        //    IAppSettings settings)
        //{
        //    ownerManager = new OwnerManager(emailService, configuration, settings);
        //}

        public LoginController(OwnerManager ownerManager)
        {
            this.ownerManager = ownerManager;
        }

        [HttpPost]
        public ObjectResult Post([FromBody] BaseRequest<LoginDTO> request)
        {
            var response = new BaseResponse<OwnerAuthenticatedDTO>();

            try
            {
                response = ownerManager.Login(request.Dto);

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
