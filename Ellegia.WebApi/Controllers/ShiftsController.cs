﻿using Ellegia.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/warehouses/{warehouseId}/enterpriseMemembers/{employeeId}/shifts")]
    public class ShiftsController : Controller
    {
        private readonly IShiftAppService _shiftAppService;
            
        public ShiftsController(IShiftAppService shiftAppService)
        {
            _shiftAppService = shiftAppService;
        }
     
        public IActionResult GetAll(int warehouseId, int employeeId) =>
            Ok(_shiftAppService.GetAll(warehouseId, employeeId));
    }
}