using Microsoft.EntityFrameworkCore;
using Tenant.Application.Interfaces;
using Tenant.Application.Services;
using Tenant.Infrastructure;
using Tenant.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string não encontrada! Verifique o appsettings.json.");
}

Console.WriteLine($"ConnectionString: {connectionString}");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services for controllers and other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scoped services for Tenant Repository and Service
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<EmpresaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
