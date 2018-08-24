using adduo.basetype.envelope;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace adduo.restoudaobra.api.Controllers
{
    public class BaseApiController : Controller
    {
        public ObjectResult result { get; set; }

        protected void PrepareResult<T>(T response) where T : BaseEnvelope
        {
            response.Success = true;
            result = StatusCode((int)HttpStatusCode.OK, response);
        }

        protected void PrepareResult<T>(List<T> response) where T : BaseEnvelope
        {
        }


        protected void PrepareResult()
        {
            result = StatusCode((int)HttpStatusCode.OK, new { });
        }

        protected void PrepareBadRequestResult<T>(T response) where T : BaseEnvelope
        {
            result = StatusCode((int)HttpStatusCode.BadRequest, response);
        }

        protected void PrepareNotFoundResult()  
        {
            result = StatusCode((int)HttpStatusCode.NotFound, null);
        }

        protected void PrepareBadRequestResult()
        {
            result = StatusCode((int)HttpStatusCode.BadRequest, new { });
        }

        protected void PrepareErrorResult()
        {
            result = StatusCode((int)HttpStatusCode.InternalServerError, new { });
        }


        protected void PrepareUnauthorizedResult()
        {
            result = StatusCode((int)HttpStatusCode.Unauthorized, new { });
        }
    }
}
