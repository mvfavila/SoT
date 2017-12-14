using SoT.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SoT.Infra.Data.EntityConfig
{
    public class MenuItemConfiguration : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemConfiguration()
        {
            HasKey(m => m.Name);

            Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(m => m.ActionName)
                .HasMaxLength(50)
                .IsOptional();

            Property(m => m.ControllerName)
                .HasMaxLength(50)
                .IsOptional();

            Property(m => m.Url)
                .HasMaxLength(400)
                .IsOptional();

            Property(m => m.ClaimType)
                .HasMaxLength(50)
                .IsOptional();

            Property(m => m.ClaimValue)
                .HasMaxLength(10)
                .IsOptional();
        }
    }
}
