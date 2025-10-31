

using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreschoolManagementSystem.Domain.Entities;
using PreschoolManagementSystem.Domain.Enums;

namespace PreschoolManagementSystem.Infrastructure.Data;

public class PreschoolDbContext : DbContext
{
    public PreschoolDbContext(DbContextOptions<PreschoolDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Students> students => Set<Students>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
    public DbSet<DevelopmentAssessment> DevelopmentAssessments => Set<DevelopmentAssessment>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuMeal> MenuMeals => Set<MenuMeal>();
    public DbSet<MenuClassroom> MenuClassrooms => Set<MenuClassroom>();
    public DbSet<NutritionRecord> NutritionRecords => Set<NutritionRecord>();
    public DbSet<TuitionFee> TuitionFees => Set<TuitionFee>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<PaymentRecord> PaymentRecords => Set<PaymentRecord>();
    public DbSet<ChatSession> ChatSessions => Set<ChatSession>();
    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();
    // public DbSet<HealthPrediction> HealthPredictions => Set<HealthPrediction>();
    // public DbSet<Notification> Notifications => Set<Notification>();
    // public DbSet<NotificationReceipt> NotificationReceipts => Set<NotificationReceipt>();
    // public DbSet<ParentTeacherMessage> ParentTeacherMessages => Set<ParentTeacherMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply entity configurations automatically
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Global filters (soft delete, active flag)
        modelBuilder.Entity<User>().HasQueryFilter(u => u.IsActive);
        modelBuilder.Entity<Classroom>().HasQueryFilter(c => c.IsActive);
        modelBuilder.Entity<Students>().HasQueryFilter(s => s.Status == StudentStatus.Active);
        modelBuilder.Entity<Menu>().HasQueryFilter(m => m.IsActive);


    }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Auto-set audit fields
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
}
