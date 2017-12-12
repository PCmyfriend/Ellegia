namespace Ellegia.Application.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public OrderSpecificationsDto Specifications { get; set; }
        public OrderPaymentInfoDto PaymentInfo { get; set; }
        public string Status { get; set; }
    }
}