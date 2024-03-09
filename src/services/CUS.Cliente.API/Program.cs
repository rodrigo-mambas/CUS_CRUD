using CUS.Cliente.API.Configuration;
using CUS.Cliente.API.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CUS.Cliente.API.Recursos.Queries;
using System.Diagnostics.CodeAnalysis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(connectionString));

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
//builder.Services.AddScoped<GetClientePorCpfQueryHandler>();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();


