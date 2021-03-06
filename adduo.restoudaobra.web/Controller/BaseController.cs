﻿using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.web.model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace adduo.restoudaobra.web.controller
{
    public class BaseController : Controller
    {
        public IHostingEnvironment hostingEnvironment { get; set; }
        public IConfiguration configuration { get; set; }
        public IAppSettings setting { get; set; }
        public IHttpContextAccessor httpContextAccessor { get; set; }

        public BaseController(
            IHostingEnvironment hostingEnvironment,
            IConfiguration configuration,
            IAppSettings setting,
            IHttpContextAccessor httpContextAccessor)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.setting = setting;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected BaseViewModel<T> CreateViewModel<T>(T value)
        {
            var viewModel = new BaseViewModel<T>(value, httpContextAccessor);

            return viewModel;
        }

    }
}
