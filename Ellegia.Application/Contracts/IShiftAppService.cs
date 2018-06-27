using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts 
{
    public interface IShiftAppService
    {
        IEnumerable<ShiftDto> GetAll(int warehouseId, int employeeId);
    }
}