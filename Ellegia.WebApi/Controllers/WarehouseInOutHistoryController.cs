using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    //[Authorize]
    [Route("api/warehouses/{warehouseId}")]
    public class WarehouseInOutHistoryController : Controller
    {
        private readonly IWarehouseInOutHistoryService _warehouseInOutHistoryService;
        private readonly UserManager<EllegiaUser> _userManager;

        public WarehouseInOutHistoryController(
            IWarehouseInOutHistoryService warehouseInOutHistoryService,
            UserManager<EllegiaUser> userManager)
        {
            _warehouseInOutHistoryService = warehouseInOutHistoryService;
            _userManager = userManager;
        }
            
        [HttpGet("fullHistory")]
        public IActionResult GetWarehouseInOutHistory(int warehouseId)
        {
            return Ok(_warehouseInOutHistoryService.GetFullInOutHistory(warehouseId));
        }

        [HttpPost("in")]
        public IActionResult AddItemsToWarehouse(
            int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);

            var resultOfAddWarehouseInOutHistory =
                _warehouseInOutHistoryService.Add(userId, warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(resultOfAddWarehouseInOutHistory
                ? StatusCodes.Status201Created
                : StatusCodes.Status400BadRequest
            );
        }


        [HttpPost("out")]
        public IActionResult TakeItemsFromWarehouse(
            int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {   
            var resultOfDeleteWarehouseInOutHistory =
                _warehouseInOutHistoryService.Delete(warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(resultOfDeleteWarehouseInOutHistory
                ? StatusCodes.Status204NoContent
                : StatusCodes.Status400BadRequest
            );
        }
    }
}
