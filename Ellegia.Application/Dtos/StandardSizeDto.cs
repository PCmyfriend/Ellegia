using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class StandardSizeDto
    {
        public int Id { get; set; }

        public int PlasticBagTypeId { get; set; }
        
        [Required]
        [Range(1, float.MaxValue)]
        public float? WidthInCm { get; set; }
        
        [Required]
        [Range(1, float.MaxValue)]
        public float? HeightInCm { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? QuantityInBag { get; set; }

        public string Name { get; set; }
    }
}