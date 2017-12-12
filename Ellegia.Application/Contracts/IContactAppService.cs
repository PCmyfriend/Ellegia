using System.Collections.Generic;
using Ellegia.Application.Dtos;

namespace Ellegia.Application.Contracts
{
    public interface IContactAppService
    {
        IEnumerable<ContactDto> GetAll(int customerId);
        ContactDto GetById(int customerId, int contactId);
        ContactDto Add(int customerId, ContactDto contactDto);
        bool Remove(int customerId, int contactId);
    }
}