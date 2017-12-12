using System;
using System.Collections.Generic;
using System.Text;
using Ellegia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellegia.Infra.Data.EntityConfigurations
{
    public class ContactConfiguration: IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(c => c.ContactType)
                .WithMany()
                .HasForeignKey(c => c.ContactTypeId);
        }
    }
}
