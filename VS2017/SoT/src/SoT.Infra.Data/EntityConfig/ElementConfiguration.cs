using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class ElementConfiguration : EntityTypeConfiguration<Element>
    {
        public ElementConfiguration()
        {
            HasKey(e => e.ElementId);

            Property(e => e.Name)
                .HasMaxLength(20)
                .IsRequired();

            Property(e => e.Active)
                .IsRequired();
        }
    }
}
