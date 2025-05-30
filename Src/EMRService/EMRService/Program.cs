using EMRService.EMRService.Application;
using EMRService.EMRService.Infrastructure;
using Microsoft.EntityFrameworkCore; // Add this using directive for 'UseNpgsql'

var builder = WebApplication.CreateBuilder(args);

// Add services
string url = builder.Configuration.GetConnectionString("EMRDatabase");
builder.Services.AddDbContext<EMRDbContext>(options =>
    options.UseNpgsql(url)); // Ensure 'Microsoft.EntityFrameworkCore' is referenced in your project

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();