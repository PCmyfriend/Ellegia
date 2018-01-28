using System.Linq;
using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Repositories
{
    public class PlasticBagTypeRepository : CommonHandbookRepository<PlasticBagType>
    {
        public PlasticBagTypeRepository(EllegiaContext context) : base(context)
        {
        }

        public override PlasticBagType GetById(int id)
        {
            return GetAll()
                .SingleOrDefault(pbt => pbt.Id == id);
        }

        public override IQueryable<PlasticBagType> GetAll()
        {
            return base.GetAll()
                .Include(pbt => pbt.StandardSizes);
        }
    }
}