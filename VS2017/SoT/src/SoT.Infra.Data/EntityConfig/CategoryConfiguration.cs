using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(c => c.CategoryId);

            Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();

            HasRequired(c => c.Element)
                .WithMany()
                .HasForeignKey(c => c.ElementId);

            Ignore(c => c.ValidationResult);
        }
    }
}
