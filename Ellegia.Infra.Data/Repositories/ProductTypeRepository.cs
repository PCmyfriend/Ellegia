using Ellegia.Domain.Models;
using Ellegia.Infra.Data.Context;

namespace Ellegia.Infra.Data.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>
    {
        public ProductTypeRepository(EllegiaContext context) : base(context)
        {            
        }
    }
}
