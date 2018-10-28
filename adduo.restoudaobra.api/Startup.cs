using adduo.restoudaobra.api.providers;
using adduo.restoudaobra.dto.model;
using adduo.restoudaobra.ie.model;
using adduo.restoudaobra.ie.providers;
using adduo.restoudaobra.service;
using adduo.restoudaobra.service.ad;
using adduo.service.email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace adduo.restoudaobra.api
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
            services.AddScoped<IAppSettings>(s => s.GetService<IOptions<AppSettings>>().Value);
            services.AddTransient<IEmailService, EmailService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ScopesConfiguration.Configuration(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton<ISigningConfigurations>(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton<ITokenConfigurations>(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {

                var paramsValidation = bearerOptions.TokenValidationParameters;

                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ClockSkew = TimeSpan.Zero;

                paramsValidation.ValidateIssuer = true;
                paramsValidation.ValidateAudience = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ValidateIssuerSigningKey = true;

                bearerOptions.SaveToken = true;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddCors(c => c.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
                }));

            services.AddMvc();

            services.AddRouting();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors(build =>
                        build.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials());

            ConfigureCulture(app);
            app.UseMvc();
        }


        private void ConfigureCulture(IApplicationBuilder app)
        {

            var defaultCulture = "pt-br";
            var ci = new CultureInfo(defaultCulture);

            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.CurrencyDecimalSeparator = ",";

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo> { ci },
                SupportedUICultures = new List<CultureInfo> { ci }
            });


        }
    }
}
