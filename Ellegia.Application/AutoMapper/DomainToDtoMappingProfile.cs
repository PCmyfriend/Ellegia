using AutoMapper;
using Ellegia.Application.Dtos;
using Color = Ellegia.Domain.Models.Color;

namespace Ellegia.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateColorMap();
        }

        private void CreateColorMap()
        {
            CreateMap<Color, ColorDto>();
        }
    }
}