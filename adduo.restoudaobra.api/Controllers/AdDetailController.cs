using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.ad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("ad/detail")]
    public class AdDetailController : AuthenticatedController
    {
        public AdManager adManager { get; set; }


        public AdDetailController(
            AdManager adManager, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.adManager = adManager;

            var idOwner = GetOwner();
            this.adManager.SetOwner(idOwner);
        }


        [HttpGet]
        [AllowAnonymous]
        public ObjectResult Get(Guid guid)
        {
            var dto = new CardDetailDTO();

            var response = new BaseResponse<CardDetailDTO>(dto);

            try
            {

                dto = adManager.Detail(guid);

                response.Dto = dto;
                response.Success = true;

                base.PrepareResult<BaseResponse<CardDetailDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<CardDetailDTO>>(response);
            }

            return base.result;
        }
    }
}
