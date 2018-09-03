using System;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class WarehouseInOutHistory : Entity
    {
        public MeasurementUnit MeasurementUnit { get; set; }
        public Color Color { get; set; }
        public Shift Shift { get; set; }
        public Order Order { get; set; }
        public ProductType ProductType { get; set; }
        public FilmType FilmType { get; set; }
        public Customer Customer { get; set; }
        
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
        public int? CustomerId { get; set; }
    }
}
