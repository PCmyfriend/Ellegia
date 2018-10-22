using System;
using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class WarehouseHistoryRecordFormDto
    {
        [Required]
        public int? MeasurementUnitId { get; set; }

        [Required]
        public int? ColorId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        public int? ShiftId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FilmTypeId { get; set; }
    }
}
