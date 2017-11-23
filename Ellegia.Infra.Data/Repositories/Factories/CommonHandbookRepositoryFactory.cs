using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories.Factories
{
    public class CommonHandbookRepositoryFactory : ICommonHandbookRepositoryFactory
    {
        private readonly EllegiaContext _context;

        public CommonHandbookRepositoryFactory(EllegiaContext context)
        {
            _context = context;
        }
        
        public ICommonHandbookRepository<T> CreateRepository<T>() where T : class, ICommonHandbook
        {
            if (typeof(PlasticBagType) == typeof(T))
            {
                return (ICommonHandbookRepository<T>) new PlasticBagTypeRepository(_context);
            }
            return new CommonHandbookRepository<T>(_context);
        }
    }
}