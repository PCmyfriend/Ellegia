using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/filmTypeOptions")]
    public class FilmTypeOptionsController: CommonHandbookController<FilmTypeOptions, FilmTypeOptionsDto>
    {
        public FilmTypeOptionsController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}
