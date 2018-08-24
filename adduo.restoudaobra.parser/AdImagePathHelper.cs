using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.parser;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace adduo.restoudaobra.service.ad
{
    public class AdImagePathHelper : IAdImagePath
    {
        public Guid guid { get; set; }

        private IHostingEnvironment hostingEnvironment { get; set; }
        private IAppSettings settings { get; set; }

        public AdImagePathHelper(IHostingEnvironment hostingEnvironment, IAppSettings settings)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.settings = settings;
        }

        public void SetGuidProduct(Guid guid)
        {
            this.guid = guid;
        }

        private string PreparePath(string path)
        {
            return path.Replace("\\", "/");
        }

        public string RelativePath()
        {
            return PreparePath(Path.Combine(settings.PathAdImage, guid.ToString()));
        }

        public string RootPath()
        {
            var root = string.Empty;

            if (this.hostingEnvironment.IsDevelopment())
            {
                root = "C:/inetpub/wwwroot/adduo.restoudaobra/adduo.restoudaobra.web/wwwroot/";
            }
            else {
                root = hostingEnvironment.ContentRootPath
                        .Replace("adduo.restoudaobra.api", string.Empty)
                        .Replace("api", string.Empty);
            }

            return root;
        }

        public string PhysicalPath()
        {
            var relative = RelativePath();

            var root = RootPath();

            return PreparePath($"{root}{relative}");
        }

        public string FullPhysicalPath(string file)
        {
            var physical = PhysicalPath();

            return PreparePath(Path.Combine(physical, file));
        }

        public string FullRelativePath(string file)
        {
            var relative = RelativePath();

            return PreparePath(Path.Combine(relative, file));
        }


    }
}
