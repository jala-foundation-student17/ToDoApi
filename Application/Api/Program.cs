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
builder.Services.AddTransient<DbContextOptionsBuilder>();
builder.Services.AddTransient<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddTransient<IAssignmentRequisitionHandler, AssignmentRequisitionHandler>();
builder.Services.AddDbContext<IMySqlContext, MySqlContext>(opt=>opt.UseInMemoryDatabase("database"));

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
