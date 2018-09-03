using System.ComponentModel.DataAnnotations;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/warehouses/{warehouseId}/inOutHistory")]
    public class WarehouseInOutHistoryController : Controller
    {
        private readonly IWarehouseInOutHistoryService _warehouseInOutHistoryService;

        public WarehouseInOutHistoryController(IWarehouseInOutHistoryService warehouseInOutHistoryService)
        {
            _warehouseInOutHistoryService = warehouseInOutHistoryService;
        }

        [HttpPost]
        public IActionResult AddInOutHistory(int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var addWarehouseInOutHistoryResult =
                _warehouseInOutHistoryService.Add(warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(addWarehouseInOutHistoryResult ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest);
        }


        [HttpDelete]
        public IActionResult DeleteInOutHistory(int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var deleteWarehouseInOutHistoryResult =
                _warehouseInOutHistoryService.Delete(warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(deleteWarehouseInOutHistoryResult ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest);
        }
    }
}
