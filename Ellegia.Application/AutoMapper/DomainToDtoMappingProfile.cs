﻿using AutoMapper;
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
            CreateMeasuremntUnitMap();
            CreatePlasticBagTypeMap();
            CreateFilmTypeMap();
            CreateStandardSizeMap();
            CreateFilmTypeOption();
            CreateShift();
            CreateOrderStatus();
        }

        private void CreateColorMap()
        {
            CreateMap<Color, ColorDto>();
        }

        private void CreateContactTypeMap()
        {
            CreateMap<ContactType, ContactTypeDto>();
        }

        private void CreateMeasuremntUnitMap()
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

        private void CreateFilmTypeOption()
        {
            CreateMap<FilmTypeOption, FilmTypeOptionDto>();
        }

        private void CreateShift()
        {
            CreateMap<Shift, ShiftDto>();
        }

        private void CreateOrderStatus()
        {
            CreateMap<OrderStatus, OrderStatusDto>();   
        }

    }
}