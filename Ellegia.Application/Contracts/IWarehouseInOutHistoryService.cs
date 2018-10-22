using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{
    public interface IWarehouseInOutHistoryService  
    {
        IEnumerable<WarehouseHistoryRecordDto> GetFullInOutHistory(int warehouseId);
        bool Add(int userId, int warehouseId, WarehouseHistoryRecordFormDto warehouseHistoryRecordFormDto);
        bool Delete(int warehouseId, WarehouseHistoryRecordFormDto warehouseHistoryRecordFormDto);
    }
}
    