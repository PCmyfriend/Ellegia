using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts 
{
    public interface IContactAppService
    {
        ContactDto Add(int customerId, ContactFormDto contactDto);
        IEnumerable<ContactDto> GetAll(int customerId);
        ContactDto GetById(int customerId, int contactId);
        bool Remove(int customerId, int contactId);
    }
}