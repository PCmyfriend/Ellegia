﻿namespace Ellegia.Application.Dtos
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasCorona { get; set; }
        public int ThicknessInMicron { get; set; }
        public int ThicknessInMicronError { get; set; }
        public int HeightInMmError { get; set; }
        public int WidthInMmError { get; set; }
        public int LengthInMmError { get; set; }

        public ParentStandardSizeDto StandardSize { get; set; }
        public FilmTypeDto FilmType { get; set; }
        public FilmTypeOptionDto FilmTypeOption { get; set; }
        public ColorDto Color { get; set; }
    }
}
