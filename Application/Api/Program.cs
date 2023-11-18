using Api.Extensions;
using DataAccess;
using InfrastructureContracts.DataAccess;
using InfrastructureContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RequisitionHandlers;
using RequisitionHandlers.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddHandlers();

var connStr = builder.Configuration.GetConnectionString("MySql");
builder.Services.DataAccess(connStr);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x=>x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
