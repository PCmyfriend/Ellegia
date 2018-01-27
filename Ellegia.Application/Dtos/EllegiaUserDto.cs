using System.Collections.Generic;

namespace Ellegia.Application.Dtos
{
    public class EllegiaUserDto
    {   
        public IEnumerable<ShiftDto> Shifts { get; private set; }
        public WarehouseDto Warehouse { get; private set; }

        public int WarehouseId { get; private set; }
    }
}
