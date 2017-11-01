using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(r => r.RegionId);

            Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(r => r.Active)
                .IsRequired();

            HasRequired(r => r.Continent)
                .WithMany()
                .HasForeignKey(r => r.ContinentId);

            Ignore(r => r.ValidationResult);
        }
    }
}
