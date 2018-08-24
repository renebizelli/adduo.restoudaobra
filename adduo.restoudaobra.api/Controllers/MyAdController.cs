using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.ad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("myad")]
    public class MyAdController : AuthenticatedController
    {
        public AdManager adManager { get; set; }


        public MyAdController(
            AdManager adManager, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.adManager = adManager;

            var idOwner = GetOwner();
            this.adManager.SetOwner(idOwner);
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var response = new BaseResponse<MyAdDTO>();

            try
            {
                var dto = adManager.MyAdListView();

                response.Dto = dto;
                response.Success = true;

                base.PrepareResult<BaseResponse<MyAdDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<MyAdDTO>>(response);
            }

            return base.result;
        }
    }
}
