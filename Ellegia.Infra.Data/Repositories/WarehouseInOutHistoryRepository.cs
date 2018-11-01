using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Ellegia.Infra.Data.Repositories
{
    public class WarehouseInOutHistoryRepository : Repository<WarehouseHistoryRecord>
    {
        public WarehouseInOutHistoryRepository(EllegiaContext context)  
            : base(context)
        {

        }

        public override WarehouseHistoryRecord GetById(int id)
        {
            return GetAll()
                .SingleOrDefault(w => w.Id == id);
        }

        public override IQueryable<WarehouseHistoryRecord> GetAll()
        {
            return base.GetAll()
                .Include(whr => whr.ProductType)
                .ThenInclude(whr => whr.FilmType)
                .ThenInclude(whr => whr.Children)
                .Include(whr => whr.ProductType)
                .ThenInclude(whr => whr.StandardSize)
                .ThenInclude(whr => whr.PlasticBagType)
                .Include(whr => whr.ProductType)
                .ThenInclude(whr => whr.FilmTypeOption)
                .Include(whr => whr.FilmType)
                .Include(whr => whr.Order)
                .Include(whr => whr.MeasurementUnit)
                .Include(whr => whr.Shift)
                .Include(whr => whr.Color)
                .Include(whr => whr.Customer);
        }
    }
}
    