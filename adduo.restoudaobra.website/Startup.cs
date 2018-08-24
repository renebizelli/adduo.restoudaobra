using adduo.restoudaobra.dto.model;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace adduo.restoudaobra.website
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


                var urlSpa = new[]
                {
                    "identificacao",
                    "quero-doar",
                    "quero-vender",
                    "quero-vender/pagamento",
                    "cadastro/confirmacao/{guid}",
                    "cadastro/redefinir-senha/",
                    "cadastro/redefinir-senha/{key}",
                    "meus-dados",
                    "meus-anuncios",
                    "meus-anuncios/anuncio/{id}",
                    "contato",
                    "politica-de-privacidade",
                    "termos-de-uso"
                };

                foreach (var url in urlSpa)
                {
                    routes.MapRoute(
                        name: $"spa-{url}",
                        template: url,
                        defaults: new { controller = "SPA", action = "Index" });
                }

            });
        }
    }
}