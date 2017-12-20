using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class PlasticBagTypeConfiguration : CommonHandbookConfiguration<PlasticBagType>
    {
        public PlasticBagTypeConfiguration(int namePropertyMaxLength) : base(namePropertyMaxLength)
        {

        }

        public override void Configure(EntityTypeBuilder<PlasticBagType> builder)
        {
            base.Configure(builder);

            builder.HasMany(pbt => pbt.StandardSizes)
                .WithOne(ss => ss.PlasticBagType)
                .HasForeignKey(ss => ss.PlasticBagTypeId);
        }
    }
}