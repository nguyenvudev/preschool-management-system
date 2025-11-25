// Infrastructure/Data/Configurations/UserConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table configuration
            builder.ToTable("Users");
            
            // Primary Key
            builder.HasKey(u => u.Id);

            // ✅ CHỈ database concerns - không validation logic
            builder.Property(u => u.Email)
                .IsRequired() // NOT NULL constraint
                .HasMaxLength(255) // Storage optimization
                .HasConversion(
                    v => v.ToLowerInvariant(), // Consistent storage
                    v => v
                );

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.AvatarUrl)
                .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(u => u.PreschoolId)
                .IsRequired();

            builder.Property(u => u.RefreshToken)
                .HasMaxLength(1000);

            // ✅ Performance indexes
            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");

            builder.HasIndex(u => u.PreschoolId)
                .HasDatabaseName("IX_Users_PreschoolId");

            builder.HasIndex(u => new { u.Role, u.IsActive })
                .HasDatabaseName("IX_Users_Role_IsActive");

            builder.HasIndex(u => u.RefreshToken)
                .HasDatabaseName("IX_Users_RefreshToken")
                .HasFilter("[RefreshToken] IS NOT NULL");

            // ✅ Query Filters
            builder.HasQueryFilter(u => !u.IsDeleted && u.IsActive);

            // ✅ Relationships
            // builder.HasOne(u => u.Preschool)
            //     .WithMany(p => p.Users)
            //     .HasForeignKey(u => u.PreschoolId)
            //     .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AuditLogs)
                .WithOne(al => al.User)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}