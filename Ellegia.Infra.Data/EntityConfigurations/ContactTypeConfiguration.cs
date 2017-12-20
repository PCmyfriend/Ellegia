using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            
        }
    }
}
