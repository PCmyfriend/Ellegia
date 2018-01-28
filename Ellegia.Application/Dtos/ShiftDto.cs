using System.ComponentModel.DataAnnotations;
using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Dtos
{
    public class ShiftDto : ICommonHandbook
    {
        public int Id { get; set; }

        public int SupervisorId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
