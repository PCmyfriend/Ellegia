using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{
    public interface IWarehouseInOutHistoryService  
    {
        IEnumerable<WarehouseHistoryRecordDto> GetInOutHistory(int warehouseId);
        WarehouseHistoryRecordDto Add(int userId, int warehouseId, WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto);
        WarehouseHistoryRecordDto Delete(int warehouseId, WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto);
    }
}   
        