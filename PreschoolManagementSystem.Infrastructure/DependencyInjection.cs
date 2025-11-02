using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.Interfaces.Repositories;
using PreschoolManagementSystem.Application.Services;
using PreschoolManagementSystem.Infrastructure.Data;
using PreschoolManagementSystem.Infrastructure.Repositories;
using PreschoolManagementSystem.Infrastructure.Services;
using PreschoolManagementSystem.Infrastructure.Repository;

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
           services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

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



            var jwtSettings = configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)

   
                };
            });
            return services;
        }
    }
}
