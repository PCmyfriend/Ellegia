using System.Collections.Generic;

namespace Ellegia.Application.Dtos
{
    public class WarehouseDto   
    {
        public IEnumerable<EllegiaUserDto> Employees { get; set; }
        public IEnumerable<WarehouseInOutHistoryItemDto> InOutHistory { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
