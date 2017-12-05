using Ellegia.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    public abstract class BaseController<TInputEntityDto, TOutputEntityDto> : Controller
        where TInputEntityDto : class
        where TOutputEntityDto : class
    {
        protected readonly IAppService<TInputEntityDto, TOutputEntityDto> _baseAppService;

        protected BaseController(IAppService<TInputEntityDto, TOutputEntityDto> appService)
        {
            _baseAppService = appService;
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var entity = _baseAppService.GetById(id);

            return entity == null
                ? (IActionResult) NotFound()
                : Ok(entity);
        }

        [HttpGet]
        public virtual IActionResult GetAll() => Ok(_baseAppService.GetAll());

        [HttpPost]
        public virtual IActionResult Add([FromBody] TInputEntityDto entityDto)
        {
            var entity = _baseAppService.Add(entityDto);

            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            if (_baseAppService.GetById(id) == null)
                return NotFound();
            
            _baseAppService.Remove(id);

            return NoContent();
        }
    }
}