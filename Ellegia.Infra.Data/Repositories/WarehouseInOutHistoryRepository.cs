using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories
{
    public class WarehouseInOutHistoryRepository : Repository<WarehouseHistoryRecord>
    {
        public WarehouseInOutHistoryRepository(EllegiaContext context)  
            : base(context)
        {

        }
    }
}
    