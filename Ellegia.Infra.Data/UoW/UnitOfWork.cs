using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Core.Commands;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Ellegia.Infra.Data.Repositories;
using Ellegia.Infra.Data.Repositories.Factories;

namespace Ellegia.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EllegiaContext _context;
        public ICommonHandbookRepository<Color> Colors { get; }
        public ICommonHandbookRepository<PlasticBagType> PlasticBagTypes { get; }

        public UnitOfWork(EllegiaContext context)
        {
            _context = context;
            Colors = CreateCommonHandbookRepository<Color>();
            PlasticBagTypes = CreateCommonHandbookRepository<PlasticBagType>();
        }
        
        public CommandResponse Complete()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public ICommonHandbookRepository<TEntity> CreateCommonHandbookRepository<TEntity>() 
            where TEntity : class, ICommonHandbook
        {
            return new CommonHandbookRepositoryFactory(_context).CreateRepository<TEntity>();
        }

        public IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}