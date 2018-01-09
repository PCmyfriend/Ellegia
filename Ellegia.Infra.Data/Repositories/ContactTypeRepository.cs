using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories
{
    public class ContactTypeRepository : Repository<ContactType>
    {
        public ContactTypeRepository(EllegiaContext context) : base(context)
        {
        }
    }
}
