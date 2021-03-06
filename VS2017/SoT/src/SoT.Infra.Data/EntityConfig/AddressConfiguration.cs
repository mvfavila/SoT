﻿using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(a => a.AddressId);

            Property(a => a.Street01)
                .HasMaxLength(300)
                .IsRequired();

            Property(a => a.Complement)
                .HasMaxLength(300)
                .IsOptional();

            Property(a => a.Postcode)
                .HasMaxLength(30)
                .IsOptional();

            Property(a => a.AdventureId)
                .IsRequired();

            Ignore(s => s.ValidationResult);
        }
    }
}
