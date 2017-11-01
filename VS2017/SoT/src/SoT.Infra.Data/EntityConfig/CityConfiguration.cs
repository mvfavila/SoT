using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            HasKey(c => c.CityId);

            Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();

            HasRequired(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId);

            Ignore(c => c.ValidationResult);
        }
    }
}
