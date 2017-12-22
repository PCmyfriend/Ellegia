using Microsoft.EntityFrameworkCore;

namespace Ellegia.Infra.Data.Context.Seeding
{
    public interface ISeeder
    {
        void Seed(DbContext context);
    }
}