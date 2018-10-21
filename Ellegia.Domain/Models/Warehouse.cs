using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Core.Models;
using Ellegia.Domain.Services.Strategy;

namespace Ellegia.Domain.Models
{
    public class Warehouse : Entity
    {
        public ICollection<EllegiaUser> Employees { get; private set; }
        public ICollection<WarehouseInOutItem> InOutHistory { get; private set; }

        public string Name { get; private set; }

        protected Warehouse()
        {
            Employees = new Collection<EllegiaUser>();
            InOutHistory = new Collection<WarehouseInOutItem>();
        }
            
        public Warehouse(int id, string name)
            : this()
        {
            Id = id;
            Name = name;    
        }   
            
        public void Add(WarehouseInOutItem warehouseItem)
        {
            InOutHistory.Add(warehouseItem);
        }
            
        public bool IsWarehouseTakeAllowed(WarehouseInOutItem warehouseInOutItem)
        {
            if (warehouseInOutItem.ProductTypeId != null)
            {
                var warehouseTake = new WarehouseTake(new ProductTypeTakeStrategy());
                return warehouseTake.Compute(warehouseInOutItem, this.InOutHistory.ToList());
            }

            if (warehouseInOutItem.FilmTypeId != null)
            {
                var warehouseTake = new WarehouseTake(new FilmTypeTakeStrategy());
                return warehouseTake.Compute(warehouseInOutItem, this.InOutHistory.ToList());
            }

            return true;
        }

        public EllegiaUser FindEmployee(int id)
        {   
            return Employees.SingleOrDefault(e => e.Id == id);      
        }

        public bool IsWarehouseInOutHistoryValid(WarehouseInOutItem warehouseInOutItem)
        {
            return warehouseInOutItem.ProductTypeId == null || warehouseInOutItem.FilmType == null;
        }
    }
}
