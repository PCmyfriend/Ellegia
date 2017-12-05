using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos.Order
{
    public class OrderFormDto
    {
        [Required]
        public OrderSpecificationsFormDto Specifications { get; set; }
    }
}