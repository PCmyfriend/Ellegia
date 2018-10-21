using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Authorize]
    [Route("api/warehouses/{warehouseId}/history")]
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
            
        [HttpGet]
        public IActionResult GetInOutHistory(int warehouseId)
        {
            return Ok(_warehouseInOutHistoryService.GetFullInOutHistory(warehouseId));
        }

        [HttpPost]
        public IActionResult AddHistoryRecord(int warehouseId, [FromBody] WarehouseHistoryRecordFormDto historyRecordFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);

            var isOperationSuccessful = historyRecordFormDto.Amount > 0 
                ? _warehouseInOutHistoryService.Add(userId, warehouseId, historyRecordFormDto) 
                : _warehouseInOutHistoryService.Delete(warehouseId, historyRecordFormDto);

            return StatusCode(isOperationSuccessful
                ? StatusCodes.Status201Created
                : StatusCodes.Status400BadRequest
            );
        }
    }
}
