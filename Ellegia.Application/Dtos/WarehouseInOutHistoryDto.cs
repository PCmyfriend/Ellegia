using System;

namespace Ellegia.Application.Dtos
{
    public class WarehouseInOutHistoryDto
    {
        public int WarehouseId { get; set; }
        public int CreatedById { get; set; }
        public int MeasurementUnitId { get; set; }
        public int ColorId { get; set; }
        public int Amount { get; set; }
        public DateTime OperationDateTime { get; set; }
        public int? ShiftId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FilmTypeId { get; set; }
    }
}
