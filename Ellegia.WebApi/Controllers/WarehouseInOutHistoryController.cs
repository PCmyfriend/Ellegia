using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/warehouses/{warehouseId}/inOutHistory")]
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

        [HttpPost]
        public IActionResult AddInOutHistory(int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);

            var addWarehouseInOutHistoryResult =
                _warehouseInOutHistoryService.Add(userId, warehouseId, warehouseInOutHistoryFormDto);

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
