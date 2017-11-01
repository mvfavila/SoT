using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class ContinentConfiguration : EntityTypeConfiguration<Continent>
    {
        public ContinentConfiguration()
        {
            HasKey(c => c.ContinentId);

            Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();
        }
    }
}
