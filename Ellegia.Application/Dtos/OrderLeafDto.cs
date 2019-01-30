using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Dtos
{
    public class OrderLeafDto
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal TotalPrice { get; set; }
        public int HolderId { get; set; }
    }
}
