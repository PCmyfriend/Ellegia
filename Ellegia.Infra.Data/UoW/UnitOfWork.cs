using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Core.Commands;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Ellegia.Infra.Data.Repositories;

namespace Ellegia.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EllegiaContext _context;
        public ICommonHandbookRepository<FilmTypeOptions> FilmTypeOptions { get; }
        public ICommonHandbookRepository<Color> Colors { get; }
        public ICommonHandbookRepository<FilmType> FilmTypes { get; }


        public UnitOfWork(EllegiaContext context)
        {
            _context = context;

            FilmTypeOptions = new CommonHandbookRepository<FilmTypeOptions>(context);
            Colors = new CommonHandbookRepository<Color>(context);
            FilmTypes = new CommonHandbookRepository<FilmType>(context);
        }
        
        public CommandResponse Complete()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public ICommonHandbookRepository<TEntity> CreateRepository<TEntity>() where TEntity : class, ICommonHandbook
        {
            return new CommonHandbookRepository<TEntity>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}