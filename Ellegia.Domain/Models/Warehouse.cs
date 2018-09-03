using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Core.Models;

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
            
        public bool IsRealeaseAllowed(WarehouseInOutHistory warehouseInOutHistory)
        {
            if (warehouseInOutHistory.ProductTypeId == null)
            {
                var warehouseInOutHistoriesAmountSum = this.WarehouseInOutHistories
                    .Where(wh => wh.FilmTypeId == warehouseInOutHistory.FilmTypeId
                                 && wh.ColorId == warehouseInOutHistory.ColorId)
                    .Sum(wh => wh.Amount);

                if (warehouseInOutHistoriesAmountSum + warehouseInOutHistory.Amount < 0)

                    return false;
            }
            else
            {
                var warehouseInOutHistoriesAmountSum = this.WarehouseInOutHistories
                    .Where(wh => wh.ProductTypeId == warehouseInOutHistory.ProductTypeId
                                 && wh.ColorId == warehouseInOutHistory.ColorId)
                    .Sum(wh => wh.Amount);

                if (warehouseInOutHistoriesAmountSum + warehouseInOutHistory.Amount < 0)

                    return false;
            }

            return true;
        }

        public EllegiaUser FindEmployee(int id)
        {   
            return Employees.SingleOrDefault(e => e.Id == id);  
        }

        public bool ValidateWarehouseInOutHistory(WarehouseInOutHistory warehouseInOutHistory)
        {
            return warehouseInOutHistory.ProductTypeId == null || warehouseInOutHistory.FilmType == null;
        }
    }
}
