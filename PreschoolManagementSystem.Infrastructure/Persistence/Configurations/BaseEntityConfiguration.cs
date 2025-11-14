using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Infrastructure.Persistence.Configurations
{
    public static class BaseEntityConfiguration
    {
        public static void ConfigureBaseEntity<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100);

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(e => e.IsDeleted)
                .IsRequired();
        }
    }
}