using Ellegia.Domain.Models;

namespace Ellegia.Application.Dtos
{
    public class OrderFormDto
    {
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal TotalSum { get; set; }
        public int ProductTypeId { get; set; }
    }
}
