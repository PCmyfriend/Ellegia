namespace Ellegia.Application.Dtos.Order
{
    public class OrderSpecificationsDto
    {
        public OrderStandardSizeDto StandardSize { get; set; }
        public FilmTypeOptionDto FilmTypeOption { get; set; }
        public FilmTypeDto FilmType { get; set; }
        public ColorDto Color { get; set; }
        public int QuantityInKg { get; set; }
        public bool HasCorona { get; set;  }
        public float ThicknessInMicron { get; set;  }
    }
}