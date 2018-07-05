using System.IO;
using AutoMapper;
using Ellegia.Application.AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Services.PdfFileIO.PdfFileReader;
using Ellegia.Domain.Services.PdfFileIO.PdfFileWriter;
using Ellegia.Infra.Data.UoW;
using Ellegia.Infra.Data.Utilities.ConfigurationReader;
using Ellegia.Infra.Data.Utilities.ConfigurationReader.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ellegia.Infra.CrossCutting.IoC
{
    public class ServicesBootstrapper
    {
        private ServicesBootstrapper()
        {
            // intentionally left empty
        }

        public static void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(AutoMapperConfig.RegisterMappings()));
            
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application - Services
            services.AddScoped<IContactAppService, ContactAppService>();
            services.AddScoped<IContactTypeAppService, ContactTypeAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IOrderRouteAppService, OrderRouteAppService>();
            services.AddScoped<IProductTypeAppService, ProductTypeAppService>();
            services.AddScoped<IShiftAppService, ShiftAppService>();        
            services.AddScoped<IStandardSizeAppService, StandardSizeAppService>();

            services.AddScoped<IConfigurationReader, EllegiaConfigurationReader>(ecr => new EllegiaConfigurationReader(configuration));

            // Domain
            services.AddTransient<IPdfFileReader>(sp =>
                new PdfFileReader(Path.Combine(sp.GetService<IHostingEnvironment>().WebRootPath, configuration["PdfTemplate:FileName"])));
            services.AddTransient<IPdfFileWriter>(sp => new PdfFileWriter());
        }
    }
}