using System.Linq;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories
{
    public class CommonHandbookRepository<TEntity> 
        : Repository<TEntity>, ICommonHandbookRepository<TEntity> where TEntity: class, ICommonHandbook
    {
        private readonly EllegiaContext _context;

        public CommonHandbookRepository(EllegiaContext context) : base(context)
        {
            _context = context;
        }

        public TEntity GetByName(string name)
        {
            return GetAll().FirstOrDefault(ch => ch.Name == name);
        }
    }
}