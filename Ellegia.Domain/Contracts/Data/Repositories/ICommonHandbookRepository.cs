using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Domain.Contracts.Data.Repositories
{
    public interface ICommonHandbookRepository<TEntity> : IRepository<TEntity> where TEntity: class, ICommonHandbook
    {
        TEntity GetByName(string name);
    }
}