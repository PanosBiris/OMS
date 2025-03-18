using Microsoft.EntityFrameworkCore;
using PB.OMS.OrderingService.Application;
using PB.OMS.OrderingService.Application.Repository;
using PB.OMS.OrderingService.Infrastructure;
using PB.OMS.OrderingService.Infrastructure.Repositories;
using Scalar.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
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

        // Apply migrations automatically
        ApplyMigrations(app);

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
    }

    private static void ApplyMigrations(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<OrdersContext>();

            // Check and apply pending migrations
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                Console.WriteLine("Applying pending migrations...");
                dbContext.Database.Migrate();
                Console.WriteLine("Migrations applied successfully.");
            }
            else
            {
                Console.WriteLine("No pending migrations found.");
            }
        }
    }
}
