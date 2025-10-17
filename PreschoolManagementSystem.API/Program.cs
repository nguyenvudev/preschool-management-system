using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PreschoolManagementSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Preschool Management API",
        Version = "v1",
        Description = "API for managing preschool system"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Preschool Management API v1");
        c.RoutePrefix = string.Empty; 
    });
}

builder.Services.AddDbContext<PreschoolDbContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

