using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.ad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("ad/status")]
    public class AdStatusController : AuthenticatedController
    {
        public AdManager adManager { get; set; }


        public AdStatusController(
            AdManager adManager, 
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.adManager = adManager;

            var idOwner = GetOwner();
            this.adManager.SetOwner(idOwner);
        }

        [HttpPut]
        public ObjectResult Put([FromBody] BaseRequest<AdChangeStatusDTO> request)
        {
            var dto = request.Dto;

            dto.idOwner = GetOwner();

            var response = new BaseResponse<AdChangeStatusDTO>(dto);

            try
            {
                adManager.ChangeStatus(request);

                base.PrepareResult<BaseResponse<AdChangeStatusDTO>>(response);
            }
            catch (Exception ex)
            {
                base.PrepareBadRequestResult<BaseResponse<AdChangeStatusDTO>>(response);
            }

            return base.result;

        }

    }
}
