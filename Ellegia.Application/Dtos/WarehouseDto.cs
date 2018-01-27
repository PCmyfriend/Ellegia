using System.Collections.Generic;

namespace Ellegia.Application.Dtos
{
    public class WarehouseDto   
    {
        public IEnumerable<EllegiaUserDto> Employees { get; private set; }
        public int Id { get; set; }
        public string Name { get; private set; }
    }
}
