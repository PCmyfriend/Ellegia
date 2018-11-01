using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Services.Strategies
{
    public abstract class ReceptionStrategy 
    {
        public abstract bool Compute(WarehouseHistoryRecord warehouseInOutItemToTake,
            List<WarehouseHistoryRecord> warehouseInOutHistories);
    }
            
    public class ProductTypeReceptionStrategy : ReceptionStrategy
    {   
        public override bool Compute(WarehouseHistoryRecord warehouseInOutItemToTake,   
            List<WarehouseHistoryRecord> warehouseInOutHistories)    
        {
            var totalAmount = warehouseInOutHistories
                    .Where(wh => wh.ProductTypeId == warehouseInOutItemToTake.ProductTypeId
                                 && wh.ColorId == warehouseInOutItemToTake.ColorId)
                    .Sum(wh => wh.Amount);

            return totalAmount + warehouseInOutItemToTake.Amount > 0;
        }
    }
        
    public class FilmTypeReceptionStrategy : ReceptionStrategy
    {
        public override bool Compute(WarehouseHistoryRecord warehouseInOutItemToTake,
            List<WarehouseHistoryRecord> warehouseInOutHistories)
        {
            var totalAmount = warehouseInOutHistories
                .Where(wh => wh.FilmTypeId == warehouseInOutItemToTake.FilmTypeId
                             && wh.ColorId == warehouseInOutItemToTake.ColorId)
                .Sum(wh => wh.Amount);

            return totalAmount + warehouseInOutItemToTake.Amount > 0;
        }
    }
}   
