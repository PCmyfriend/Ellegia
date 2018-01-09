using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class StandardSizeConfiguration : IEntityTypeConfiguration<StandardSize>
    {
        public void Configure(EntityTypeBuilder<StandardSize> builder)
        {
        }
    }
}