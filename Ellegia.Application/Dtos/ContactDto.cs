using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public ContactTypeDto ContactType { get; set; }

        public ContactDto()
        {
            ContactType = new ContactTypeDto();
        }
    }
}
