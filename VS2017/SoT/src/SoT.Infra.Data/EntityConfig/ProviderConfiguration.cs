using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class ProviderConfiguration : EntityTypeConfiguration<Provider>
    {
        public ProviderConfiguration()
        {
            HasKey(p => p.ProviderId);

            Property(p => p.CompanyName)
                .HasMaxLength(400)
                .IsRequired();

            Property(p => p.Active)
                .IsRequired();

            Property(p => p.RegisterDate)
                .IsRequired();

            Ignore(p => p.ValidationResult);
        }
    }
}
