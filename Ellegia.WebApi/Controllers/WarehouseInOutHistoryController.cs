﻿using Ellegia.Application.Contracts;
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
            var warehouseInOutHistoryDto = _warehouseInOutHistoryService.GetInOutHistory(warehouseId);
            return Ok(warehouseInOutHistoryDto);
        }

        [HttpPost]  
        public IActionResult AddHistoryRecord(int warehouseId, [FromBody] WarehouseInOutHistoryRecordFormDto warehouseInOutHistoryRecordFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);

            if (warehouseInOutHistoryRecordFormDto.Amount > 0)
            {   
                var addedWarehouseInOutHistoryRecordDto = 
                    _warehouseInOutHistoryService.Add(userId, warehouseId, warehouseInOutHistoryRecordFormDto);

                return addedWarehouseInOutHistoryRecordDto == null
                    ? (IActionResult) StatusCode(StatusCodes.Status400BadRequest)
                    : StatusCode(StatusCodes.Status200OK, addedWarehouseInOutHistoryRecordDto);
            }
    
            var deletedWarehouseInOutHistoryRecordDto =
                _warehouseInOutHistoryService.Delete(warehouseId, warehouseInOutHistoryRecordFormDto);

            return deletedWarehouseInOutHistoryRecordDto == null
                ? (IActionResult)StatusCode(StatusCodes.Status400BadRequest)
                : StatusCode(StatusCodes.Status200OK, deletedWarehouseInOutHistoryRecordDto);
        }
    }
}
    