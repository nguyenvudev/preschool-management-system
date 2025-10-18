using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Infrastructure.Data;
using PreschoolManagementSystem.Infrastructure.Repository;

namespace PreschoolManagementSystem.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PreschoolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IStudentRepository, StudentRepository>();


            return services;
        }
    }
}
