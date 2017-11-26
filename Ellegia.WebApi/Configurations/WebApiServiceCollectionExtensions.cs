using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Ellegia.WebApi.Configurations
{
    public static class WebApiServiceCollectionExtensions
    {
        public static IMvcBuilder AddWebApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var builder = services.AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer()
                .AddCors()
                .AddDataAnnotations()
                .AddAuthorization();
            
            return new MvcBuilder(builder.Services, builder.PartManager);
        }

        public static IMvcBuilder AddWebApi(this IServiceCollection services, Action<MvcOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            var builder = AddWebApi(services);
            builder.Services.Configure(setupAction);

            return builder;
        }
    }
}