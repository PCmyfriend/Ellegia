using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>
    {
        public ProductTypeRepository(EllegiaContext context) : base(context)
        {
        }

        public override IQueryable<ProductType> GetAll()
        {
            return base.GetAll()
                .Include(pt => pt.FilmType)
                .Include(pt => pt.Color)
                .Include(pt => pt.StandardSize)
                .Include(pt => pt.FilmTypeOption);
        }
    }
}
