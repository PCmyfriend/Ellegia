using System;
using System.IO;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using Ellegia.Domain.Models;
using Ellegia.Infra.CrossCutting.IoC;
using Ellegia.Infra.Data.Context;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Contracts;
using Ellegia.WebApi.Configurations;
using Ellegia.WebApi.Constants;
using Ellegia.WebApi.MvcFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ellegia.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EllegiaContext>();

            services.AddIdentity<EllegiaUser, EllegiaRole>(options =>
                {
                    options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                    options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                    options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
                })
                .AddEntityFrameworkStores<EllegiaContext>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = OAuthValidationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OAuthValidationDefaults.AuthenticationScheme;
                })
                .AddOAuthValidation();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddDistributedMemoryCache();
            
            services.AddOpenIddict<int>(options =>
            {
                options.AddEntityFrameworkCoreStores<EllegiaContext>();
                options.AddMvcBinders();
                options.EnableTokenEndpoint($"/{Routes.TokenEndpoint}");
                options.AllowPasswordFlow();
                options.DisableHttpsRequirement();
            });

            services.AddWebApi(options =>
            {
                options.Filters.Add(new ModelStateValidationFilter());
            });

            services.AddAutoMapper();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, IConfigurationReader configurationReader)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMvc();

            //EllegiaContext.Seed(serviceProvider, Configuration, configurationReader);
        }

        private void RegisterServices(IServiceCollection services)
        {
            ServicesBootstrapper.RegisterServices(services, Configuration);
        }
    }
}