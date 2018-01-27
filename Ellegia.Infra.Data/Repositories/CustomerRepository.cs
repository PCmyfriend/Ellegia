using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(EllegiaContext context) : base(context)
        {

        }

        public override Customer GetById(int id)
        {
            return GetAll()
                .SingleOrDefault(c => c.Id == id);
        }

        public override IQueryable<Customer> GetAll()
        {
            return base.GetAll()
                .Include(c => c.Contacts)
                .ThenInclude(c => c.ContactType);
        }
    }
}
