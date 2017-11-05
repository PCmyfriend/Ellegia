using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;

namespace Ellegia.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateColorMap();
        }

        private void CreateColorMap()
        {
            CreateMap<ColorDto, Color>();
        }
    }
}