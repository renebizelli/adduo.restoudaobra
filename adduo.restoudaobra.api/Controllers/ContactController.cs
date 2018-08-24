using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.contact;
using Microsoft.AspNetCore.Mvc;
using System;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("contact")]
    public class ContactController : BaseApiController
    {
        public ContactManager contactManager { get; set; }

        public ContactController(ContactManager contactManager)
        {
            this.contactManager = contactManager;
        }

        [HttpPost]
        public ObjectResult Post([FromBody] BaseRequest<ContactDTO> request)
        {
            try
            {
                var response = contactManager.Send(request);

                if (response.Success)
                {
                    base.PrepareResult<BaseResponse<ContactDTO>>(response);
                }
                else
                {
                    base.PrepareBadRequestResult<BaseResponse<ContactDTO>>(response);
                }
            }
            catch (Exception ex)
            {
                base.PrepareErrorResult();
            }

            return base.result;
        }
    }
}
