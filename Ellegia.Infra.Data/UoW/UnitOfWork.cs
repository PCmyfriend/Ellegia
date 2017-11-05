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
        public IRepository<Color> Colors { get; }

        public UnitOfWork(EllegiaContext context)
        {
            _context = context;
            Colors = new Repository<Color>(context);
        }
        
        public CommandResponse Complete()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}