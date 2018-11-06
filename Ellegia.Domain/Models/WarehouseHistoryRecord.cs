using System;
using Ellegia.Domain.Constants;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class WarehouseHistoryRecord : Entity, ICommonHandbook
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
        public double Amount { get; private set; }
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
        public string FormattedOperationDateTime => OperationDateTime.ToString("dd/MM/yyyy HH:mm:ss");

        public string Name
        {
            get
            {
                if (ProductType != null)
                    return ProductType.Name;

                if (FilmType != null)
                    return FilmType.Name;

                return WarehouseHistoryRecordType.DefaultNameRecord;
            }
        }

        public string Type
        {
            get
            {
                if (ProductType != null)
                    return WarehouseHistoryRecordType.ProductTypeRecord;

                if (FilmType != null)
                    return WarehouseHistoryRecordType.FilmTypeRecord;

                return WarehouseHistoryRecordType.DefaultTypeRecord;
            }
        }
    }
}
