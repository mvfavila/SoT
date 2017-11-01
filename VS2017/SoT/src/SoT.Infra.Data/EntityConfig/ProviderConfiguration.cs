using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class ProviderConfiguration : EntityTypeConfiguration<Provider>
    {
        public ProviderConfiguration()
        {
            HasKey(p => p.ProviderId);

            Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Name)
                .HasMaxLength(400)
                .IsRequired();

            Property(p => p.CompanyName)
                .HasMaxLength(400)
                .IsRequired();

            Property(p => p.Active)
                .IsRequired();

            Ignore(p => p.ValidationResult);
        }
    }
}
