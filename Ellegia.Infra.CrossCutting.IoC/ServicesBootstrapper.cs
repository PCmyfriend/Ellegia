using AutoMapper;
using Ellegia.Application.AutoMapper;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Core.Services;
using Ellegia.Infra.Data.UoW;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Ellegia.Infra.CrossCutting.IoC
{
    public class ServicesBootstrapper
    {
        private ServicesBootstrapper()
        {
            // intentionally left empty
        }

        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(AutoMapperConfig.RegisterMappings()));
            
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Core
            services.AddTransient<ITextFileReader>(sp =>
                new TextFileReader(sp.GetService<IHostingEnvironment>().WebRootPath));
        }
    }
}