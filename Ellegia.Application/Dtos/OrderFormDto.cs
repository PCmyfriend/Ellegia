using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class OrderFormDto
    {
        [Required]
        public int? CustomerId { get; set; }
        
        [Required]
        public int? WarehouseId { get; set; }
        
        [Required]
        public int? QuantityInKg { get; set; }
        
        [Required]
        public decimal? PricePerKg { get; set; }
        
        [Required]
        public int? ProductTypeId { get; set; }
    }
}
