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
            
        [HttpGet("inOutHistory")]
        public IActionResult GetInOutHistories(int warehouseId)
        {
            return Ok(_warehouseInOutHistoryService.GetInOutHistories(warehouseId));
        }
        

        [HttpPost("addInOutHistory")]
        public IActionResult AddInOutHistory(int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);

            var addWarehouseInOutHistoryResult =
                _warehouseInOutHistoryService.Add(userId, warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(addWarehouseInOutHistoryResult ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest);
        }


        [HttpPost("deleteInOutHistory")]
        public IActionResult DeleteInOutHistory(int warehouseId, [FromBody] WarehouseInOutHistoryFormDto warehouseInOutHistoryFormDto)
        {
            var deleteWarehouseInOutHistoryResult =
                _warehouseInOutHistoryService.Delete(warehouseId, warehouseInOutHistoryFormDto);

            return StatusCode(deleteWarehouseInOutHistoryResult ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest);
        }
    }
}
