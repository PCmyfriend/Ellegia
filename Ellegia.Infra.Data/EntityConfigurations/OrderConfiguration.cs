using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Ignore(o => o.Name);
            
            builder
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            
            builder
                .HasOne(o => o.Warehouse)
                .WithMany()
                .HasForeignKey(o => o.WarehouseId);
            
            builder
                .HasOne(o => o.ProductType)
                .WithMany()
                .HasForeignKey(o => o.ProductTypeId); 
        }
    }
}
