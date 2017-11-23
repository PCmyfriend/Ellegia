using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class StandardSizeDto
    {
        public int Id { get; set; }
        
        [Required]
        [Range(1, double.MaxValue)]
        public float? WidthInCm { get; set; }
        
        [Required]
        [Range(1, double.MaxValue)]
        public float? LengthInCm { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? QuantityInBag { get; set; }
        
        [Range(1, double.MaxValue)]
        public float? HeightInCm { get; set; }
    }
}