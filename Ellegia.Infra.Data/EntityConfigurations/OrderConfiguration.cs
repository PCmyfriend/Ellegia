using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Specifications)
                .WithOne()
                .HasForeignKey<OrderSpecifications>(os => os.Id);

            builder.HasOne(o => o.PaymentInfo)
                .WithOne()
                .HasForeignKey<OrderPaymentInfo>(opi => opi.Id);
        }
        
    }
}