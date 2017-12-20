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
            CreateMeasurementUnitMap();
            CreatePlasticBagTypeMap();
            CreateFilmTypeMap();
            CreateFilmTypeOptionsMap();
            CreateShiftMap();
            CreateStandardSizeMap();
            CreateCustomerMap();
            CreateContactMap();
        }

        public void CreateShiftMap()
        {
            CreateMap<ShiftDto, Shift>();
        }

        public void CreateFilmTypeOptionsMap()
        {
            CreateMap<FilmTypeOptionDto, FilmTypeOption>();
        }

        public void CreateFilmTypeMap()
        {
            CreateMap<FilmTypeDto, FilmType>();
        }

        private void CreateColorMap()
        {
            CreateMap<ColorDto, Color>();
        }
        
        private void CreateContactTypeMap()
        {
            CreateMap<ContactTypeDto, ContactType>();
        }

        private void CreateMeasurementUnitMap()
        {
            CreateMap<MeasurementUnitDto, MeasurementUnit>();
        }

        private void CreatePlasticBagTypeMap()
        {
            CreateMap<PlasticBagTypeDto, PlasticBagType>();
        }

        private void CreateStandardSizeMap()
        {
            CreateMap<StandardSizeDto, StandardSize>();
        }

        private void CreateCustomerMap()
        {
            CreateMap<CustomerDto, Customer>();
        }

        private void CreateContactMap()
        {
            CreateMap<ContactDto, Contact>();
        }
    }
}