using Ellegia.Domain.Models;

namespace Ellegia.Application.Dtos
{
    public class WarehouseHistoryRecordDto
    {   
        public ShiftDto Shift { get; set; }
        //public OrderDto Order { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public FilmTypeDto FilmType { get; set; }
        public MeasurementUnitDto MeasurementUnit { get; set; }
        public ColorDto Color { get; set; }
        public Customer Customer { get; private set; }

        public int Id { get; set; }
        public int? ShiftId { get; private set; }
        public int? OrderId { get; private set; }
        public int? ProductTypeId { get; private set; }
        public int? FilmTypeId { get; private set; }
        public int? CustomerId { get; private set; }
        public int MeasurementUnitId { get; private set; }
        public int ColorId { get; private set; }

        public string Type { get; set; }        
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public int Amount { get; set; } 
        public string OperationDateTimeFormatted { get; set; }
    }
}
