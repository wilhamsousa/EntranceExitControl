using Cronis.VehicleControl.Api.Controllers.Notification;
using Cronis.VehicleControl.Api.Extensions;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterDependencyInjections();
        builder.Services.RegisterMaps();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContextPool<ExcContext>(
            options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        logger.LogInformation("Application started!");
        logger.LogInformation("DefaultConnection: " + builder.Configuration.GetConnectionString("DefaultConnection"));

        builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());
        //            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);        

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.ApplyMigration();

        app.Run();
    }
}