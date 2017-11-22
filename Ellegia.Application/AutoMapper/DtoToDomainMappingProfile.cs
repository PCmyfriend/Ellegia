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
            CreateContactTypeMap();
            CreateMeasuremntUnitMap();
            CreatePlasticBagTypeMap();
            CreateFilmTypeMap();
            CreateFilmTypeOptions();
            CreateShift();
            CreateOrderStatus();
        }

        private void CreateColorMap()
        {
            CreateMap<ColorDto, Color>();
        }
        
        private void CreateContactTypeMap()
        {
            CreateMap<ContactTypeDto, ContactType>();
        }

        private void CreateMeasuremntUnitMap()
        {
            CreateMap<MeasurementUnitDto, MeasurementUnit>();
        }

        private void CreatePlasticBagTypeMap()
        {
            CreateMap<PlasticBagTypeDto, PlasticBagType>();
        }
        private void CreateFilmTypeMap()
        {
            CreateMap<FilmTypeDto, FilmType>();
        }
        private void CreateFilmTypeOptions()
        {
            CreateMap<FilmTypeOptionDto, FilmTypeOption>();
        }

        private void CreateShift()
        {
            CreateMap<ShiftDto, Shift>();
        }
        private void CreateOrderStatus()
        {
            CreateMap<OrderStatusDto, OrderStatus>();
        }
    }
}