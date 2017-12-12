using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Dtos.Order;
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
            CreateOrderStandardSizeMap();
            CreateOrderSpecificationsMap();
            CreateOrderPaymentInfoMap();
            CreateOrderMap();
            CreateCustomerMap();
            CreateContactMap();
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

        private void CreateOrderStandardSizeMap()
        {
            CreateMap<StandardSize, OrderStandardSizeDto>();
        }

        private void CreateOrderSpecificationsMap()
        {
            CreateMap<OrderSpecifications, OrderSpecificationsDto>();
        }

        private void CreateOrderPaymentInfoMap()
        {
            CreateMap<OrderPaymentInfo, OrderPaymentInfoDto>()
                .ForMember(src => src.Status,
                           opts => opts.MapFrom(o => o.Status.ToString()));
        }

        private void CreateOrderMap()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(src => src.Status,
                           opts => opts.MapFrom(o => o.Status.ToString()));
        }

        private void CreateCustomerMap()
        {
            CreateMap<Customer, CustomerDto>();
        }

        private void CreateContactMap()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}