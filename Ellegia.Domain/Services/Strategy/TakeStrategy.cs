﻿using System.Collections.Generic;
using System.Linq;
using Ellegia.Domain.Models;

namespace Ellegia.Domain.Services.Strategy
{
    public abstract class TakeStrategy
    {
        public abstract bool Compute(WarehouseInOutItem warehouseInOutItemToTake,
            List<WarehouseInOutItem> warehouseInOutHistories);
    }
            
    public class ProductTypeTakeStrategy : TakeStrategy
    {   
        public override bool Compute(WarehouseInOutItem warehouseInOutItemToTake,
            List<WarehouseInOutItem> warehouseInOutHistories)    
        {
            var totalAmount = warehouseInOutHistories
                    .Where(wh => wh.ProductTypeId == warehouseInOutItemToTake.ProductTypeId
                                 && wh.ColorId == warehouseInOutItemToTake.ColorId)
                    .Sum(wh => wh.Amount);



            return totalAmount + warehouseInOutItemToTake.Amount > 0;
        }
    }
        
    public class FilmTypeTakeStrategy : TakeStrategy
    {
        public override bool Compute(WarehouseInOutItem warehouseInOutItemToTake,
            List<WarehouseInOutItem> warehouseInOutHistories)
        {
            var totalAmount = warehouseInOutHistories
                .Where(wh => wh.FilmTypeId == warehouseInOutItemToTake.FilmTypeId
                             && wh.ColorId == warehouseInOutItemToTake.ColorId)
                .Sum(wh => wh.Amount);

            return totalAmount + warehouseInOutItemToTake.Amount > 0;
        }
    }

    public class WarehouseTake
    {   
        private readonly TakeStrategy _takeStrategy;
        
        public WarehouseTake(TakeStrategy takeStrategy)
        {
            _takeStrategy = takeStrategy;
        }

        public bool Compute(WarehouseInOutItem warehouseInOutItemToTake, List<WarehouseInOutItem> warehouseInOutHistories)
        {
            return _takeStrategy.Compute(warehouseInOutItemToTake, warehouseInOutHistories);
        }
    }
}   
