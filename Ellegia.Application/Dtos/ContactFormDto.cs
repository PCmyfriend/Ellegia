using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class ContactFormDto
    {    
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int ContactTypeId { get; set; }
    }
}
