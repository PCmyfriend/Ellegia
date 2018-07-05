using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class OrderRouteDto
    {
        [Required]
        public int? RecipientId { get; set; }
        public string Comment { get; set; }
    }
}
