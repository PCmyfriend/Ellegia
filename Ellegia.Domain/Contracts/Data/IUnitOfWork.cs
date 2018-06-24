using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Contracts.Data.Repositories.Factories;
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
        ICommonHandbookRepository<PlasticBagType> PlasticBagTypes { get; }
        IRepository<Customer> Customers { get; }     
        IRepository<ContactType> ContactTypes { get; } 
        IRepository<ProductType> ProductTypes { get; } 
        IOrderRepository Orders { get; } 
        IRepository<OrderRoute> OrderRoutes { get; }
        IRepository<Warehouse> Warehouses { get; }
        IRepository<EllegiaUser> Users { get; }

        CommandResponse Complete();

        ICommonHandbookRepository<TEntity> CreateCommonHandbookRepository<TEntity>() where TEntity : class, ICommonHandbook;
        IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class;
    }
}