﻿using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class ProductType : Entity
    {
        public FilmType FilmType { get; private set; }
        public StandardSize StandardSize { get; private set; }
        public FilmTypeOption FilmTypeOption { get; private set; }
        public Color Color { get; private set; }

        public string Name { get; private set; }
        public int FilmTypeId { get; private set; }
        public int StandardSizeId { get; private set; }
        public int FilmTypeOptionId { get; private set; }
        public bool HasCorona { get; private set; }
        public int ThicknessInMicron { get; private set; }
        public int ThicknessInMicronError { get; private set; }
        public int HeightInMmError { get; private set; }
        public int WidthInMmError { get; private set; }
        public int LengthInMmError { get; private set; }
        public int ColorId { get; private set; }

        protected ProductType()
        {
            // required by EF
        }

        public ProductType(
            string name, 
            int filmTypeId, 
            int standardSizeId, 
            int filmTypeOptionId, 
            bool hasCorona, 
            int thicknessInMicron, 
            int thicknessInMicronError, 
            int heightInMmError, 
            int widthInMmError, 
            int lengthInMmError, 
            int colorId)
        {
            Name = name;
            FilmTypeId = filmTypeId;
            StandardSizeId = standardSizeId;
            FilmTypeOptionId = filmTypeOptionId;
            HasCorona = hasCorona;
            ThicknessInMicron = thicknessInMicron;
            ThicknessInMicronError = thicknessInMicronError;
            HeightInMmError = heightInMmError;
            WidthInMmError = widthInMmError;
            LengthInMmError = lengthInMmError;
            ColorId = colorId;            
        }
    }
}