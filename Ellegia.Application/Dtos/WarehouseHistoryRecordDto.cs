namespace Ellegia.Application.Dtos
{
    public class WarehouseHistoryRecordDto
    {   
        public ShiftDto Shift { get; set; }
        public OrderLeafDto Order { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public FilmTypeDto FilmType { get; set; }
        public MeasurementUnitDto MeasurementUnit { get; set; }
        public ColorDto Color { get; set; }
        public CustomerDto Customer { get; set; }

        public int Id { get; set; }
        public int? ShiftId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? FilmTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int MeasurementUnitId { get; set; }
        public int ColorId { get; set; }
        public string Type { get; set; }        
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public int Amount { get; set; } 
        public string OperationDateTimeFormatted { get; set; }
    }
}
