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
            CreateProductTypeMap();
            CreateOrderMap();
            CreateWarehouseMap();
            CreateEllegiaUserMap();
            CreateOrderRouteMap();
            CreateWarehouseInOutHistoryMap();
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
            CreateMap<ContactFormDto, Contact>();
        }

        private void CreateProductTypeMap()
        {
            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<ProductTypeFormDto, ProductType>();
        }

        private void CreateOrderMap()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<OrderFormDto, Order>();
        }

        private void CreateEllegiaUserMap()
        {
            CreateMap<EllegiaUserDto, EllegiaUser>();
        }

        private void CreateOrderRouteMap()
        {
            CreateMap<OrderRouteDto, OrderRoute>();
        }

        private void CreateWarehouseMap()
        {
            CreateMap<WarehouseDto, Warehouse>();
        }

        private void CreateWarehouseInOutHistoryMap()
        {
            CreateMap<WarehouseInOutHistoryRecordFormDto, WarehouseHistoryRecord>();
        }
    }
}