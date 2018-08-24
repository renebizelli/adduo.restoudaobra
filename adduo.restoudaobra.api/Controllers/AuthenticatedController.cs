using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace adduo.restoudaobra.api.Controllers
{
    [Authorize("Bearer")]
    public class AuthenticatedController : BaseApiController
    {

        public IHttpContextAccessor httpContextAccessor  { get; set; }

        public AuthenticatedController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected int GetOwner()
        {
            var result = 0;

            var identity = this.httpContextAccessor.HttpContext.User.Identity;

            if (identity != null && identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)identity;
                var id = claimsIdentity.FindFirst("id").Value;
                int.TryParse(id, out result);
            }

            return result;
        }
    }
}
