using System.IO;
using AutoMapper;
using Ellegia.Infra.CrossCutting.IoC;
using Ellegia.Infra.Data.Context;
using Ellegia.WebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            services.AddWebApi();

            services.AddAutoMapper();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();

            app.Run(async context => { await context.Response.WriteAsync("Resource is not found."); });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            ServicesBootstrapper.RegisterServices(services);
        }
    }
}