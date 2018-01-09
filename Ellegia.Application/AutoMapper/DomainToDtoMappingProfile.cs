using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;
using Color = Ellegia.Domain.Models.Color;

namespace Ellegia.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateColorMap();
            CreateContactTypeMap();
            CreateMeasurementUnitMap();
            CreatePlasticBagTypeMap();
            CreateFilmTypeMap();
            CreateStandardSizeMap();
            CreateFilmTypeOptionMap();
            CreateShiftMap();
            CreateCustomerMap();
            CreateContactMap();
            CreateProductTypeMap();
        }

        private void CreateColorMap()
        {
            CreateMap<Color, ColorDto>();
        }

        private void CreateContactTypeMap()
        {
            CreateMap<ContactType, ContactTypeDto>();
        }
            
        private void CreateMeasurementUnitMap()
        {
            CreateMap<MeasurementUnit, MeasurementUnitDto>();
        }

        private void CreatePlasticBagTypeMap()
        {
            CreateMap<PlasticBagType, PlasticBagTypeDto>();
        }

        private void CreateStandardSizeMap()
        {
            CreateMap<StandardSize, StandardSizeDto>();
        }

        private void CreateFilmTypeMap()
        {
            CreateMap<FilmType, FilmTypeDto>();
        }

        private void CreateFilmTypeOptionMap()
        {
            CreateMap<FilmTypeOption, FilmTypeOptionDto>();
        }

        private void CreateShiftMap()
        {
            CreateMap<Shift, ShiftDto>();
        }

        private void CreateCustomerMap()
        {
            CreateMap<Customer, CustomerDto>();
        }

        private void CreateContactMap()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<Contact, ContactFormDto>();
        }

        private void CreateProductTypeMap()
        {
            CreateMap<ProductType, ProductTypeDto>();
        }
    }
}