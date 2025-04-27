using EMRService.EMRService.Application;
using EMRService.EMRService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<EMRDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("EMRDatabase")));

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
