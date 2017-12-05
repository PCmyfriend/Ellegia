namespace Ellegia.Application.Dtos.Order
{
    public class OrderStandardSizeDto
    {
        public PlasticBagTypeDto PlasticBagType { get; set; }
        public int Id { get; set; }
        public float WidthInCm { get; set; }
        public float HeightInCm { get; set; }
        public int QuantityInBag { get; set; }
    }
}