using Ellegia.Domain.Contracts.Data.Repositories;
using Ellegia.Domain.Core.Commands;
using Color = Ellegia.Domain.Models.Color;

namespace Ellegia.Domain.Contracts.Data
{
    public interface IUnitOfWork
    {
        IRepository<Color> Colors { get; }
        CommandResponse Complete();
    }
}