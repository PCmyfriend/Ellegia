using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/plasticBagTypes/{plasticBagTypeId}/standardSizes")]
    public class StandardSizesController : Controller
    {

        private readonly StandardSizeAppService _standardSizeAppService;
        
        public StandardSizesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _standardSizeAppService = new StandardSizeAppService(mapper, unitOfWork);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int plasticBagTypeId, int id)
        {
            var standardSize = _standardSizeAppService.GetById(plasticBagTypeId, id);

            if (standardSize == null)
                return NotFound();
            
            return Ok(standardSize);
        }

        [HttpGet]
        public IActionResult GetAll(int plasticBagTypeId) => 
            Ok(_standardSizeAppService.GetAll(plasticBagTypeId));

        [HttpPost]
        public IActionResult Add(int plasticBagTypeId, [FromBody] StandardSizeDto standardSizeDto)
        {   
            var standardSize = _standardSizeAppService.Add(plasticBagTypeId, standardSizeDto);

            if (standardSize == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, standardSize);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int plasticBagTypeId, int id) => 
            _standardSizeAppService.Remove(plasticBagTypeId, id)
            ? (IActionResult) NoContent()
            : NotFound();
    }
}