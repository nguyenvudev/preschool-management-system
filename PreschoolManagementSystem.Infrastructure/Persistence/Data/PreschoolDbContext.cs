

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PreschoolManagementSystem.Infrastructure.Data;

public class PreschoolDbContext : DbContext
{
    public PreschoolDbContext(DbContextOptions<PreschoolDbContext> options) : base(options)
    {

    }
    
}
