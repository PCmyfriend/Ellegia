using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class OrderRouteDto
    {
        [Required]
        public int RecepientId { get; set; }
        public string Comment { get; set; }
    }
}
