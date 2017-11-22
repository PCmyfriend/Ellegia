using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Application.Dtos
{
    public class OrderStatusDto : ICommonHandbook
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
