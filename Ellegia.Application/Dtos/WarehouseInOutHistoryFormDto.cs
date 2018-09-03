using System;
using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class WarehouseInOutHistoryFormDto
    {
        [Required]
        public int? CreatedById { get; set; }

        [Required]
        public int? MeasurementUnitId { get; set; }

        [Required]
        public int? ColorId { get; set; }

        [Required]
        public int? Amount { get; set; }

        [Required]
        public DateTime? OperationDateTime { get; set; }
        public int? ShiftId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FilmTypeId { get; set; }
    }
}
