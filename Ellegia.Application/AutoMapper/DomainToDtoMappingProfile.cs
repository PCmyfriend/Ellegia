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
            CreateStandardSizeMap();
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
    }
}