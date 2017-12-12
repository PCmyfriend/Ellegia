﻿using AutoMapper;
using Ellegia.Application.Dtos;
using Ellegia.Application.Services;
using Ellegia.Domain.Contracts.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellegia.WebApi.Controllers
{
    [Route("api/customers/{customerId}/contacts")]
    public class ContactsController : Controller 
    {
        private readonly ContactAppService _contactAppService;

        public ContactsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactAppService = new ContactAppService(mapper, unitOfWork);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int customerId, int id)    
        {
            var contact = _contactAppService.GetById(customerId, id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet]
        public IActionResult GetAll(int customerId) =>  
            Ok(_contactAppService.GetAll(customerId));

        [HttpPost]
        public IActionResult Add(int customerId, [FromBody] ContactDto contactDto)
        {
            var contact = _contactAppService.Add(customerId, contactDto);

            if (contact == null)
                return NotFound();

            return StatusCode(StatusCodes.Status201Created, contact);
        }
            
        [HttpDelete("{id}")]
        public IActionResult Delete(int customerId, int id) =>
            _contactAppService.Remove(customerId, id)
                ? (IActionResult)NoContent()
                : NotFound();
    }
}
