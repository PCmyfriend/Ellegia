using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class StandardSizeDto
    {
        public int Id { get; set; }

        public int PlasticBagTypeId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? WidthInMm { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? LengthInMm { get; set; }
        
        [Range(1, int.MaxValue)]
        public int? HeightInMm { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int? QuantityInBag { get; set; }

        public string Name { get; set; }
    }
}