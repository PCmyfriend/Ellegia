using AutoMapper;

namespace Ellegia.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        private AutoMapperConfig()
        {
            // intentionally left empty
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainMappingProfile());
            });
        }
    }
}