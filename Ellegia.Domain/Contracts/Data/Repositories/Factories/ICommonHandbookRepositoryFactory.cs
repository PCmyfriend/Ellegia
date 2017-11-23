using Ellegia.Domain.Contracts.Common;

namespace Ellegia.Domain.Contracts.Data.Repositories.Factories
{
    public interface ICommonHandbookRepositoryFactory
    {
        ICommonHandbookRepository<T> CreateRepository<T>() where T : class, ICommonHandbook;
    }
}