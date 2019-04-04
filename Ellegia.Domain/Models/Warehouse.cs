using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Core.Models;
using Ellegia.Domain.Services.Strategies;

namespace Ellegia.Domain.Models
{
    public class Warehouse : Entity
    {
        public ICollection<EllegiaUser> Employees { get; private set; }
        public ICollection<WarehouseHistoryRecord> InOutHistory { get; private set; }

        public string Name { get; private set; }

        protected Warehouse()
        {
            Employees = new Collection<EllegiaUser>();
            InOutHistory = new Collection<WarehouseHistoryRecord>();
        }
        
        public Warehouse(string name)
            : this()
        {
            Name = name;    
        }
            
        public void OrderByOperationDateTimeInOutHistory(bool desc = false)
        {
            if (desc)
            {
                InOutHistory = InOutHistory.OrderByDescending(whr => whr.OperationDateTime).ToList();
                return;
            }

            InOutHistory = InOutHistory.OrderBy(whr => whr.OperationDateTime).ToList();
        }
            
        public void Add(WarehouseHistoryRecord warehouseItem)
        {
            InOutHistory.Add(warehouseItem);
        }
            
        public bool IsWarehouseReceptionAllowed(WarehouseHistoryRecord warehouseInOutItem)
        {
            ReceptionStrategy receptionStrategy = null;

            if (warehouseInOutItem.ProductTypeId != null)
                receptionStrategy = new ProductTypeReceptionStrategy();     
            

            if (warehouseInOutItem.FilmTypeId != null)
                receptionStrategy = new FilmTypeReceptionStrategy();

            return receptionStrategy?.Compute(warehouseInOutItem, this.InOutHistory.ToList()) ?? true;
        }

        public EllegiaUser FindEmployee(int id)
        {   
            return Employees.SingleOrDefault(e => e.Id == id);      
        }

        public bool IsWarehouseInOutHistoryValid(WarehouseHistoryRecord warehouseInOutItem)
        {
            return warehouseInOutItem.ProductTypeId == null || warehouseInOutItem.FilmType == null;
        }
    }
}
