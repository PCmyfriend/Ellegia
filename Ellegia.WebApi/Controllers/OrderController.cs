using System;
using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly OrderAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;


        public OrderController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<EllegiaUser> userManager)
        {
            _orderAppService = new OrderAppService(mapper, unitOfWork);
            _userManager = userManager;
        }

        [HttpGet("{orderStatus}")]
        public IActionResult GetByType(string orderStatus)
        {
            if (!Enum.TryParse(orderStatus, true, out OrderStatus outOrderStatus))
                return BadRequest();

            return Ok(_orderAppService.GetByType(outOrderStatus));
        }

        [HttpPost]
        public IActionResult AddOrder(OrderFormDto orderFormDto)
        { 
            var orderDto = _orderAppService.Add(orderFormDto);
            return StatusCode(StatusCodes.Status201Created, orderDto);
        }
    }
}
