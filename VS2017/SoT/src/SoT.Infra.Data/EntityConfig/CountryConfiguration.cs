using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasKey(c => c.CountryId);

            Property(c => c.Name)
                .HasMaxLength(70)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();

            HasRequired(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.RegionId);

            Ignore(c => c.ValidationResult);
        }
    }
}
