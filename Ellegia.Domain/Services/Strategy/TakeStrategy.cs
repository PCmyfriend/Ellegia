using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Services.Strategy
{
    public abstract class TakeStrategy
    {
        public abstract bool Compute(WarehouseInOutHistory warehouseInOutHistoryToTake,
            List<WarehouseInOutHistory> warehouseInOutHistories);
    }
            
    public class ProductTypeTakeStrategy : TakeStrategy
    {   
        public override bool Compute(WarehouseInOutHistory warehouseInOutHistoryToTake,
            List<WarehouseInOutHistory> warehouseInOutHistories)    
        {
            var totalAmount = warehouseInOutHistories
                    .Where(wh => wh.ProductTypeId == warehouseInOutHistoryToTake.ProductTypeId
                                 && wh.ColorId == warehouseInOutHistoryToTake.ColorId)
                    .Sum(wh => wh.Amount);

            return totalAmount + warehouseInOutHistoryToTake.Amount < 0;
        }
    }
        
    public class FilmTypeTakeStrategy : TakeStrategy
    {
        public override bool Compute(WarehouseInOutHistory warehouseInOutHistoryToTake,
            List<WarehouseInOutHistory> warehouseInOutHistories)
        {
            var totalAmount = warehouseInOutHistories
                .Where(wh => wh.FilmTypeId == warehouseInOutHistoryToTake.FilmTypeId
                             && wh.ColorId == warehouseInOutHistoryToTake.ColorId)
                .Sum(wh => wh.Amount);

            return totalAmount + warehouseInOutHistoryToTake.Amount < 0;
        }
    }

    public class WarehouseTake
    {   
        private readonly TakeStrategy _takeStrategy;
        
        public WarehouseTake(TakeStrategy takeStrategy)
        {
            _takeStrategy = takeStrategy;
        }

        public bool Compute(WarehouseInOutHistory warehouseInOutHistoryToTake, List<WarehouseInOutHistory> warehouseInOutHistories)
        {
            return _takeStrategy.Compute(warehouseInOutHistoryToTake, warehouseInOutHistories);
        }
    }
}   
