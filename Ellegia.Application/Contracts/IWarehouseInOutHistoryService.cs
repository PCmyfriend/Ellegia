using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{
    public interface IWarehouseInOutHistoryService
    {
        bool Add(int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto);
        bool Delete(int warehouseId, WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto);
    }
}
    