using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Context.Seeding
{
    public abstract class BaseSeeder<T> : ISeeder where T: class
    {
        public void Seed(DbContext context)
        {
            var dbSet = context.Set<T>();

            if (dbSet.Any())
                return;
            
            dbSet.AddRange(Seeds);
            context.SaveChanges();
        }
        
        protected abstract IEnumerable<T> Seeds { get; }
    }
}