using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.website.controller;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace adduo.restoudaobra.website.controller
{
    public class SPAController : BaseController
    {
        public SPAController(
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            IAppSettings setting,
            IHttpContextAccessor httpContextAccessor) : base(hostingEnvironment, configuration, setting, httpContextAccessor)
        { }

        public IActionResult Index()
        {
            return View();
        }
    }
}