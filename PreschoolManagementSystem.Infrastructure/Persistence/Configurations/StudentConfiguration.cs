// Infrastructure/Persistence/Configurations/StudentConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.DateOfBirth)
                .IsRequired();

            builder.Property(s => s.ParentPhone)
                .HasMaxLength(20);

            builder.Property(s => s.ParentEmail)
                .HasMaxLength(255);

            builder.Property(s => s.EmergencyPhone)
                .HasMaxLength(20);

            builder.Property(s => s.Address)
                .HasMaxLength(500);

            // Relationships
            
            builder.HasOne(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(s => s.Code)
                .IsUnique();

            builder.HasIndex(s => s.ClassroomId);

            builder.HasIndex(s => new { s.Status, s.ClassroomId });
        }
    }
}