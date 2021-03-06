﻿using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class WarehouseInOutHistoryRecordFormDto
    {
        [Required]
        public int? MeasurementUnitId { get; set; }

        [Required]
        public int? ColorId { get; set; }

        [Required]
        public double Amount { get; set; }

        public int? ShiftId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FilmTypeId { get; set; }
        public int? CustomerId { get; set; }    
    }
}
