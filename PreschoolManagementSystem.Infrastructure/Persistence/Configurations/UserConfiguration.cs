

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            BaseEntityConfiguration.ConfigureBaseEntity(builder);

            
            

        }
    }
}