using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.Interfaces.Repositories;
using PreschoolManagementSystem.Application.Services;
using PreschoolManagementSystem.Infrastructure.Data;
using PreschoolManagementSystem.Infrastructure.Repositories;
using PreschoolManagementSystem.Infrastructure.Services;

namespace PreschoolManagementSystem.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PreschoolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // services.AddScoped<IStudentRepository, StudentRepository>();

            // Application Services
              // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IStudentRepository, StudentRepository>();
            // services.AddScoped<IClassroomRepository, ClassroomRepository>();
            // services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

            // Services
            services.AddScoped<ITokenService, tokenService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();
            // services.AddScoped<IStudentService, StudentService>();
            // services.AddScoped<IClassroomService, ClassroomService>();
            // services.AddScoped<IHealthService, HealthService>();


            return services;
        }
    }
}
