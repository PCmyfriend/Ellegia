using AutoMapper;
using Ellegia.Application.AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Infra.Data.UoW;
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
        }
    }
}