using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Models;    

namespace Ellegia.Application.Services
{
    public class ContactTypeAppService : AppService<ContactType, ContactTypeDto, ContactTypeDto>, IContactTypeAppService
    {
        public ContactTypeAppService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(unitOfWork.ContactTypes, mapper, unitOfWork)
        {

        }
    }
}
