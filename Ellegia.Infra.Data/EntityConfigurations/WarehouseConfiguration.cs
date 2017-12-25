using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.Property(w => w.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(w => w.Employees)
                .WithOne()
                .HasForeignKey(e => e.WarehouseId);
        }
    }
}
