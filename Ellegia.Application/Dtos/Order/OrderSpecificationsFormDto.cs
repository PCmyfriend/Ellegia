using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos.Order
{
    public class OrderSpecificationsFormDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? QuantityInKg { get; set; }
        
        [Required]
        public bool? HasCorona { get; set; }
        
        [Required]
        [Range(0, float.MaxValue)]
        public float? ThicknessInMicron { get; set; }
        
        [Required]
        public int? StandardSizeId { get; set; }
        
        [Required]
        public int? FilmTypeOptionId { get; set; }
        
        [Required]
        public int? FilmTypeId { get; set; }
        
        [Required]
        public int? ColorId { get; set; }
    }
}