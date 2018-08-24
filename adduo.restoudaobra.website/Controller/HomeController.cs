using adduo.restoudaobra.dto;
using adduo.restoudaobra.service.search;
using adduo.restoudaobra.website.model;
using adduo.restoudaobra.website.controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using adduo.restoudaobra.ie.model;

namespace adduo.restoudaobra.website.controller
{
    public class HomeController : BaseController
    {
        private SearchManager searchManager { get; set; }

        public HomeController(
            SearchManager searchManager,
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            IAppSettings setting,
            IHttpContextAccessor httpContextAccessor) : base(hostingEnvironment, configuration, setting, httpContextAccessor)
        {
            this.searchManager = searchManager;
        }

        public IActionResult Index()
        {
            BaseViewModel<List<CardSearchDTO>> result = null;

            try
            {
                var ads = searchManager.Search(string.Empty);

                result = CreateViewModel(ads);
            }
            catch (Exception ex)
            {
            }

            return View(result);
        }
    }
}