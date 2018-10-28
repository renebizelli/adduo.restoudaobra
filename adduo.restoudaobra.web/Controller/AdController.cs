using adduo.basetype.envelope;
using adduo.restoudaobra.dto;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.service.ad;
using adduo.restoudaobra.service.search;
using adduo.restoudaobra.web.model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace adduo.restoudaobra.web.controller
{
    public class AdController : BaseController
    {
        private AdManager adManager { get; set; }
        private SearchManager searchManager { get; set; }

        public AdController(
            SearchManager searchManager,
            AdManager adManager,
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            IAppSettings setting,
            IHttpContextAccessor httpContextAccessor) : base(hostingEnvironment, configuration, setting, httpContextAccessor)
        {
            this.adManager = adManager;
            this.searchManager = searchManager;
        }

        public IActionResult Index()
        {
            BaseViewModel<List<CardSearchDTO>> result = null;

            try
            {
                var ads = searchManager.Search("");

                result = CreateViewModel(ads); 
            }
            catch (Exception ex)
            {
            }

            return View(result);
        }


        public IActionResult Detail(string name, Guid guid)
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