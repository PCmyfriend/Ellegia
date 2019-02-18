using Ellegia.Domain.Enums;

namespace Ellegia.Application.Dtos
{   
    public class OrderRouteDto
    {
        public int? RecipientId { get; set; }
        public string Comment { get; set; }
        public OrderStatus NewOrderStatus { get; set; }
        public OrderStatus OldOrderStatus { get; set; }
    }
}
