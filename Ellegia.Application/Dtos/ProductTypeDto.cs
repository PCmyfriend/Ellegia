namespace Ellegia.Application.Dtos
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public int StandardSizeId { get; set; }
        public int FilmTypeOptionId { get; set; }
        public int ColorId { get; set; }
        public bool HasCorona { get; set; }
        public int ThicknessInMicron { get; set; }
        public int ThicknessInMicronError { get; set; }
        public int HeightInMmError { get; set; }
        public int WidthInMmError { get; set; }
        public int LengthInMmError { get; set; }

        public StandardSizeDto StandardSizes { get; set; }
        public FilmTypeDto FilmTypes { get; set; }
        public FilmTypeOptionDto FilmTypeOptions { get; set; }
        public ColorDto ColorDto { get; set; }
    }
}
