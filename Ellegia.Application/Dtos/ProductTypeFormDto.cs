using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class ProductTypeFormDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int StandardSizeId { get; set; }

        [Required]
        public int FilmTypeOptionId { get; set; }

        [Required]
        public int ColorId { get; set; }

        [Required]
        public bool HasCorona { get; set; }

        [Required]
        public int ThicknessInMicron { get; set; }

        [Required]
        public int ThicknessInMicronError { get; set; }

        [Required]
        public int HeightInMmError { get; set; }

        [Required]
        public int WidthInMmError { get; set; }

        [Required]
        public int LengthInMmError { get; set; }
    }
}
