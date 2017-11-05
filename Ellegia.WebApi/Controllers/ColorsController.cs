using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/colors")]
    public class ColorsController : Controller
    {
        private readonly IColorAppService _colorAppService;

        public ColorsController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var color = _colorAppService.GetById(id);

            return color == null
                ?(IActionResult) NotFound()
                : Ok(color);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_colorAppService.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] ColorDto colorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var color = _colorAppService.Add(colorDto);

            return Ok(color);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_colorAppService.GetById(id) == null)
                return NotFound();
            
            _colorAppService.Remove(id);

            return Ok();
        }
    }
}