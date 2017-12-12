using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Dtos
{
    public class CustomerDto : ICommonHandbook
    {
        public IEnumerable<ContactDto> Contacts { get; set; }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public CustomerDto()
        {
            Contacts = new Collection<ContactDto>();
        }
    }
}
