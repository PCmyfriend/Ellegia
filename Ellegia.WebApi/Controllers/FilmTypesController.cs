using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{

    [Route("api/filmTypes")]
    public class FilmTypesController : CommonHandbookController<FilmType, FilmTypeDto>
    {
        public FilmTypesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }
    }
}
