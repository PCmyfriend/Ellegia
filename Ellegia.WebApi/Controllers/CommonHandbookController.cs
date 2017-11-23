using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    public abstract class CommonHandbookController<TEntity, TEntityDto> : Controller 
        where TEntity : class, ICommonHandbook
        where TEntityDto : class, ICommonHandbook
    {
        private readonly ICommonHandbookAppService<TEntity, TEntityDto> _appService;

        protected CommonHandbookController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appService = new CommonHandbookAppService<TEntity, TEntityDto>(mapper, unitOfWork);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _appService.GetById(id);

            return entity == null
                ? (IActionResult) NotFound()
                : Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_appService.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] TEntityDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_appService.GetByName(entityDto.Name) != null)
                return BadRequest($"{entityDto.Name} has aready existed.");
            
            var entity = _appService.Add(entityDto);

            return CreatedAtAction("Add", entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_appService.GetById(id) == null)
                return NotFound();
            
            _appService.Remove(id);

            return NoContent();
        }
    }
}