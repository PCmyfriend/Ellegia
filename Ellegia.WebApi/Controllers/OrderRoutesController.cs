using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
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
        private readonly OrderRouteAppService _orderAppService;
        private readonly UserManager<EllegiaUser> _userManager;

        public OrderRoutesController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<EllegiaUser> userManager)
        {
            _orderAppService = new OrderRouteAppService(mapper, unitOfWork);
            _userManager = userManager;
        }

        [HttpGet("permittedRoutes")]
        public IActionResult GetPermittedRoute()
        {
            var userId = int.Parse(_userManager.GetUserId(User));
            return Ok(_orderAppService.GetPermittedRoutes(userId));
        }

        [HttpPost]
        public IActionResult AddOrderRoute(int orderId, OrderRouteDto orderRouteDto)
        {
            var userId = int.Parse(_userManager.GetUserId(User));

            orderRouteDto = _orderAppService.AddOrderRoute(orderId, userId, orderRouteDto);

            if (orderRouteDto == null)
                return BadRequest();

            return StatusCode(StatusCodes.Status201Created, orderRouteDto);
        }
    }
}
