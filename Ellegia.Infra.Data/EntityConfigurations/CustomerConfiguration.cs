using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasMany(c => c.Contacts)
                .WithOne()
                .HasForeignKey(c=>c.CustomerId);
        }       
    }
}
