using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    public abstract class CommonHandbookController<TEntity, TEntityDto> 
        : BaseController<TEntityDto, TEntityDto>
        where TEntity : class, ICommonHandbook
        where TEntityDto : class, ICommonHandbook
    {
        private readonly ICommonHandbookAppService<TEntityDto> _appService;

        protected CommonHandbookController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(new CommonHandbookAppService<TEntity, TEntityDto>(mapper, unitOfWork))
        {
            _appService = (CommonHandbookAppService<TEntity, TEntityDto>) _baseAppService;
        }

        public override IActionResult Add([FromBody] TEntityDto entityDto)
        {
            if (_appService.GetByName(entityDto.Name) != null)
                return BadRequest($"{entityDto.Name} has aready existed.");
            
            var entity = _appService.Add(entityDto);

            return StatusCode(StatusCodes.Status201Created, entity);
        }
    }
}