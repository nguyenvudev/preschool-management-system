using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PreschoolManagementSystem.Application.Interfaces;
using PreschoolManagementSystem.Application.MappingProfiles;
using PreschoolManagementSystem.Infrastructure.Data;
using PreschoolManagementSystem.Infrastructure.Persistence;
using PreschoolManagementSystem.Infrastructure.Repository;
using PreschoolManagementSystem.Application;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
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
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Preschool Management API v1");
        c.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

