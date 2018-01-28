using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class FilmTypeRepository : CommonHandbookRepository<FilmType>
    {
        public FilmTypeRepository(EllegiaContext context) : base(context)
        {
        }

        public override IQueryable<FilmType> GetAll()
        {
            return base.GetAll()
                .Include(ft => ft.Children)
                .ThenInclude(ft => ft.Children)
                .ThenInclude(ft => ft.Children)
                .Where(ft => ft.ParentId == null);
        }
    }
}