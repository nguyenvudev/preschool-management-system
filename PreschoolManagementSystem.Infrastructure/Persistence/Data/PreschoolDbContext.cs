

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreschoolManagementSystem.Domain.Entities;

namespace PreschoolManagementSystem.Infrastructure.Data;

public class PreschoolDbContext : DbContext
{
    public PreschoolDbContext(DbContextOptions<PreschoolDbContext> options) : base(options)
    {

    }
       public DbSet<Students> Students { get; set; }
 

    
}
