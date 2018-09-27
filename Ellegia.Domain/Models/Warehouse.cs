using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Core.Models;
using Ellegia.Domain.Services.Strategy;

namespace Ellegia.Domain.Models
{
    public class Warehouse : Entity
    {
        public ICollection<EllegiaUser> Employees { get; private set; }
        public ICollection<WarehouseInOutHistory> WarehouseInOutHistories { get; private set; }

        public string Name { get; private set; }

        protected Warehouse()
        {
            Employees = new Collection<EllegiaUser>();
            WarehouseInOutHistories = new Collection<WarehouseInOutHistory>();
        }
            
        public Warehouse(int id, string name)
            : this()
        {
            Id = id;
            Name = name;    
        }   
            
        public void Accept(WarehouseInOutHistory warehouseInOutHistory)
        {
            WarehouseInOutHistories.Add(warehouseInOutHistory);
        }
            
        public bool IsWarehouseTakeAllowed(WarehouseInOutHistory warehouseInOutHistory)
        {
            if (warehouseInOutHistory.ProductTypeId != null)
            {
                var warehouseTake = new WarehouseTake(new ProductTypeTakeStrategy());
                return warehouseTake.Compute(warehouseInOutHistory, this.WarehouseInOutHistories.ToList());
            }

            if (warehouseInOutHistory.FilmTypeId != null)
            {
                var warehouseTake = new WarehouseTake(new FilmTypeTakeStrategy());
                return warehouseTake.Compute(warehouseInOutHistory, this.WarehouseInOutHistories.ToList());
            }

            return true;
        }

        public EllegiaUser FindEmployee(int id)
        {   
            return Employees.SingleOrDefault(e => e.Id == id);      
        }

        public bool IsWarehouseInOutHistoryValid(WarehouseInOutHistory warehouseInOutHistory)
        {
            return warehouseInOutHistory.ProductTypeId == null || warehouseInOutHistory.FilmType == null;
        }
    }
}
