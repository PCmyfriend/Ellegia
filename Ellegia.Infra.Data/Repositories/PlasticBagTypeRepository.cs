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
            return DbSet.Include(pbt => pbt.StandardSizes).SingleOrDefault(pbt => pbt.Id == id);
        }
    }
}