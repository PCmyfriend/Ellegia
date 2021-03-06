﻿using System;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Authorize]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;

        public OrdersController(UserManager<EllegiaUser> userManager, IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
            _userManager = userManager;
        }

        [HttpGet("{orderStatus}")]
        public IActionResult GetByType(int orderStatus)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), orderStatus))
                return BadRequest($"Order status {orderStatus} is not defined.");

            var userId = _userManager.GetUserIdAsInt(User);
            return Ok(_orderAppService.GetByType((OrderStatus) orderStatus, userId));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderFormDto orderFormDto)
        {
            var userId = _userManager.GetUserIdAsInt(User);
            var orderDto = _orderAppService.Add(userId, orderFormDto);

            return StatusCode(StatusCodes.Status201Created, orderDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           return _orderAppService.Remove(id)
                ? (IActionResult)NoContent()
                : NotFound();
        }
           
        [HttpGet]
        [Route("{orderId}/printingVersion")]
        public IActionResult GetOrderPrintingVersion(int orderId)
        {
            var bytes = _orderAppService.GetOrderPrintingVersion(orderId);

            if (bytes == null)
                return BadRequest();        

            return File(bytes, "application/pdf");
        }
    }
}
