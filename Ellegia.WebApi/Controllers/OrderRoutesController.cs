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
    [Route("api/orders/{orderId}/routes")]
    public class OrderRoutesController : Controller
    {   
        private readonly IOrderRouteAppService _orderRouteAppService;
        private readonly UserManager<EllegiaUser> _userManager;
            
        public OrderRoutesController(UserManager<EllegiaUser> userManager, IOrderRouteAppService orderRouteAppService)
        {
            _orderRouteAppService = orderRouteAppService;   
            _userManager = userManager;
        }

        [HttpGet("permittedRoutes")]
        public IActionResult GetPermittedRoute()
        {
            var userId = _userManager.GetParsedToIntUserId(User);   
            return Ok(_orderRouteAppService.GetPermittedRoutes(userId));
        }

        [HttpPost]
        public IActionResult AddOrderRoute(int orderId, OrderRouteDto orderRouteDto)
        {
            var userId = _userManager.GetParsedToIntUserId(User);
            orderRouteDto = _orderRouteAppService.AddOrderRoute(orderId, userId, orderRouteDto);

            if (orderRouteDto == null)
                return BadRequest();

            return StatusCode(StatusCodes.Status201Created, orderRouteDto);
        }
    }
}