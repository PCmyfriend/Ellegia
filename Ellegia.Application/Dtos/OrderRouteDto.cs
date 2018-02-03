using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class OrderRouteDto
    {
        public int Id { get; set; }

        [Required]
        public int RecepientId { get; set; }
        public string Comment { get; set; }
    }
}
