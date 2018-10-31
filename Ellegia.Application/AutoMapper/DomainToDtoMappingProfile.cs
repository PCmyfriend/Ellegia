using System.Globalization;
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
            CreateOrderMap();
            CreateWarehouseMap();
            CreateWarehouseHistoryRecordMap();
            CreateEllegiaUserMap();
            CreateOrderRouteMap();
            CreatePermittedOrderRouteMap();
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
            CreateMap<PlasticBagType, CommonHandbookDto>();
        }

        private void CreateStandardSizeMap()
        {
            CreateMap<StandardSize, StandardSizeDto>();
            CreateMap<StandardSize, ParentStandardSizeDto>();
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
            CreateMap<ProductType, ProductTypeFormDto>();
        }

        private void CreateOrderMap()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderFormDto>();
        }

        private void CreateWarehouseMap()
        {
            CreateMap<Warehouse, WarehouseDto>();
        }

        private void CreateWarehouseHistoryRecordMap()
        {
            CreateMap<WarehouseHistoryRecord, WarehouseHistoryRecordDto>();
        }

        private void CreateEllegiaUserMap()
        {
            CreateMap<EllegiaUser, EllegiaUserDto>();
        }

        private void CreateOrderRouteMap()
        {
            CreateMap<OrderRoute, OrderRouteDto>();
        }

        private void CreatePermittedOrderRouteMap()
        {
            CreateMap<EllegiaUser, PermittedOrderRouteDto>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoleName, opts => opts.MapFrom(src => string.Join(", ", src.Roles)));
        }
    }
}