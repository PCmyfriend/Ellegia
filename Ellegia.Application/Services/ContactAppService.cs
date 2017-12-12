using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ellegia.Application.Contracts;
using Ellegia.Application.Dtos;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Models;

namespace Ellegia.Application.Services
{
    public class ContactAppService : IContactAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonHandbookRepository<Customer> _customerRepository;

        public ContactAppService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = unitOfWork.Customers;
        }

        public IEnumerable<ContactDto> GetAll(int customerId)
        {
            var customer = GetCustomerById(customerId);

            return customer == null
                ? Enumerable.Empty<ContactDto>()
                : customer.Contacts.Select(_mapper.Map<ContactDto>);
        }

        public ContactDto GetById(int customerId, int contactId)   
        {   
            var customer = GetCustomerById(customerId);
            return _mapper.Map<ContactDto>(customer?.FindContact(contactId));
        }

        public ContactDto Add(int customerId, ContactDto contactDto)
        {
            var customer = GetCustomerById(customerId);
                    
            if (customer == null) 
                return null;

            var contact = _mapper.Map<Contact>(contactDto);
            customer.AddContact(contact);

            _unitOfWork.Complete();

            return _mapper.Map<ContactDto>(contact);
        }

        public bool Remove(int customerId, int contactId)
        {
            var customer = GetCustomerById(customerId);

            if (customer == null || !customer.RemoveContact(contactId)) return false;

            _unitOfWork.Complete();
            return true;
        }

        private Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }

    }
}
