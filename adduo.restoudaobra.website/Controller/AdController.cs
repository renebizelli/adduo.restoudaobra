using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.service.ad;
using adduo.restoudaobra.website.model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace adduo.restoudaobra.website.controller
{
    public class AdController : BaseController
    {
        private AdManager adManager { get; set; }

        public AdController(
            AdManager adManager,
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            IAppSettings setting,
            IHttpContextAccessor httpContextAccessor) : base(hostingEnvironment, configuration, setting, httpContextAccessor)
        {
            this.adManager = adManager;
        }

        public IActionResult Index(string name, Guid guid)
        {
            BaseViewModel<CardDetailDTO> result = null;

            try
            {
                var ad = adManager.Detail(guid);

                result = CreateViewModel(ad);
            }
            catch (Exception ex)
            {
            }

            return View(result);
        }
    }
}