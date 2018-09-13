using adduo.restoudaobra.dto.model;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace adduo.restoudaobra.web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IAppSettings>(s => { return s.GetService<IOptions<AppSettings>>().Value; });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ScopesConfiguration.Configuration(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var x = new DefaultFilesOptions();
            x.DefaultFileNames = new List<string> { "index.html" };

            app.UseDefaultFiles(x);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ad-doacao",
                    template: "doacao/{name}/{guid}",
                    defaults: new { controller = "Ad", action = "Index" });

                routes.MapRoute(
                    name: "ad-venda",
                    template: "venda/{name}/{guid}",
                    defaults: new { controller = "Ad", action = "Index" });


                routes.MapRoute(
                    name: "home",
                    template: "",
                    defaults: new { controller = "Home", action = "Index" });

                ConfigureRoutes(routes);
            });
        }


        private void ConfigureRoutes(IRouteBuilder routes)
        {
            var routesSpa = new[] {
                new {  template = "/conta", name = "app-conta" },
                new {  template = "/conta/sucesso", name = "app-conta-sucesso"},
                new {  template = "/conta/confirmacao/:id", name = "app-conta-confirmacao"},
                new {  template = "/conta/redefinir-senha", name = "app-conta-redefinir-senha"},
                new {  template = "/conta/redefinir-senha/solicitada", name = "app-conta-redefinir-senha-solicitada"},
                new {  template = "/conta/redefinir-senha/sucesso", name = "app-conta-redefinir-senha-sucesso"},
                new {  template = "/conta/redefinir-senha/:key", name = "app-conta-redefinir-senha-key"},
                new {  template = "/conta/meus-dados", name = "app-conta-meus-dados"},
                new {  template = "/conta/meus-anuncios", name = "app-conta-meus-anuncios"},
                new {  template = "/conta/meus-anuncios/quero-doar/{id}", name = "app-conta-meus-anuncios-quero-doar"},
                new {  template = "/conta/meus-anuncios/quero-vender/{id}", name = "app-conta-meus-anuncios-quero-vender"},
                new {  template = "/quero-doar", name = "app-quero-doar"},
                new {  template = "/quero-vender", name = "app-quero-vender"},
                new {  template = "/quero-vender/pagamento/{id}", name = "app-quero-vender-pagamento"},
                new {  template = "/contato", name="app-contato"},
                new {  template = "/contato/enviado", name = "app-contato-enviado"}
            };

            foreach (var spa in routesSpa)
            {
                routes.MapRoute(
                    name: spa.name,
                    template: spa.template,
                    defaults: new { controller = "SPA", action = "Index" });

            }
        }
    }
}