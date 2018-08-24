using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adduo.restoudaobra.api.Controllers
{
    [Route("auth")]
    public class AuthController : AuthenticatedController
    {
        public AuthController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}
