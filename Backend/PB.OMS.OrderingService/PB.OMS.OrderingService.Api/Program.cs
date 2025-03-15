using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Application;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Infrastructure;
using PB.OMS.OrderingService.Infrastructure.Repositories;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddScoped<IOrderRepository, OrdersRepository>();
var cs = builder.Configuration.GetConnectionString("OrdersDB");
builder.Services.AddDbContext<OrdersContext>(opt => opt.UseSqlServer(cs));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
