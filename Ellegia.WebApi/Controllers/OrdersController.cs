using System;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Ellegia.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;

        public OrdersController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<EllegiaUser> userManager, IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
            _userManager = userManager;
        }

        [HttpGet("{orderStatus}")]
        public IActionResult GetByType(string orderStatus)
        {
            if (!Enum.TryParse(orderStatus, true, out OrderStatus outOrderStatus))
                return BadRequest();

            var userId = _userManager.GetParsedToIntUserId(User);
            return Ok(_orderAppService.GetByType(outOrderStatus, userId));
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderFormDto orderFormDto)
        { 
            var orderDto = _orderAppService.Add(orderFormDto);
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
