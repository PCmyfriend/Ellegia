using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Dtos
{
    public class PlasticBagTypeDto : ICommonHandbook
    {
        public IEnumerable<StandardSizeDto> StandardSizes { get; set; }
        
        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public PlasticBagTypeDto()
        {
            StandardSizes = new Collection<StandardSizeDto>();
        }
    }
}