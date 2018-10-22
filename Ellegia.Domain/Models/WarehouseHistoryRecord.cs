using System;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class WarehouseHistoryRecord : Entity
    {
        public MeasurementUnit MeasurementUnit { get; private set; }
        public Color Color { get; private set; }
        public Shift Shift { get; private set; }
        public Order Order { get; private set; }
        public ProductType ProductType { get; private set; }
        public FilmType FilmType { get; private set; }
        public Customer Customer { get; private set; }
        
        public int WarehouseId { get; private set; }    
        public int CreatedById { get; set; }
        public int MeasurementUnitId { get; private set; }
        public int ColorId { get; private set; }
        public int Amount { get; private set; }
        public DateTime OperationDateTime { get; private set; }
        public int? ShiftId { get; private set; }
        public int? OrderId { get; private set; }
        public int? ProductTypeId { get; private set; }
        public int? FilmTypeId { get; private set; }
        public int? CustomerId { get; private set; }

        public WarehouseHistoryRecord()
        {
            OperationDateTime = DateTime.UtcNow;
        }
    }
}
