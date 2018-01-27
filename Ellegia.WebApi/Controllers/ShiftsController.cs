using AutoMapper;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/warehouses/{warehouseId}/enterpriseMemembers/{emId}/shifts")]
    public class ShiftsController : Controller
    {
        private readonly ShiftAppService _shiftAppService;

        public ShiftsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _shiftAppService = new ShiftAppService(mapper, unitOfWork);
        }
     
        public IActionResult GetAll(int warehouseId, int emId) =>
            Ok(_shiftAppService.GetAll(warehouseId, emId));
    }
}