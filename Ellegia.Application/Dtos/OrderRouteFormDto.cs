using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class OrderRouteFormDto
    {
        [Required]
        public int? RecipientId { get; set; }
        public string Comment { get; set; }
    }
}   
