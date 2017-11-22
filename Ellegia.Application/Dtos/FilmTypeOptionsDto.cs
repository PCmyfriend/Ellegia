using System.ComponentModel.DataAnnotations;
using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Dtos
{
    public class FilmTypeOptionsDto : ICommonHandbook
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
