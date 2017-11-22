using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Core.Commands;
using Ellegia.Domain.Models;
using Color = Ellegia.Domain.Models.Color;

namespace Ellegia.Domain.Contracts.Data
{
    public interface IUnitOfWork    
    { 
        ICommonHandbookRepository<Color> Colors { get; }
        ICommonHandbookRepository<FilmType> FilmTypes { get; }
        ICommonHandbookRepository<FilmTypeOption> FilmTypeOptions { get; }
        ICommonHandbookRepository<Shift> Shifts { get; }
        ICommonHandbookRepository<OrderStatus> OrderStatuses { get; }
        CommandResponse Complete();

        ICommonHandbookRepository<TEntity> CreateRepository<TEntity>() where TEntity : class, ICommonHandbook;
    }
}