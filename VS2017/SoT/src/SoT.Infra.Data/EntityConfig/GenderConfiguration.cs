using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class GenderConfiguration : EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            HasKey(c => c.GenderId);

            Property(c => c.Value)
                .HasMaxLength(30)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();

            Ignore(c => c.ValidationResult);
        }
    }
}
