using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories
{
    public class WarehouseInOutHistoryRepository : Repository<WarehouseInOutHistory>
    {
        public WarehouseInOutHistoryRepository(EllegiaContext context)  
            : base(context)
        {

        }
    }
}
    