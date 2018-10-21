using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{
    public interface IWarehouseInOutHistoryService  
    {
        IEnumerable<WarehouseInOutHistoryItemDto> GetFullInOutHistory(int warehouseId);
        bool Add(int userId, int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto);
        bool Delete(int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto);
    }
}
    