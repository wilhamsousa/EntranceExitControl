using Cronis.VehicleControl.Api.Controllers.Notification;
using Cronis.VehicleControl.Application.Services;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Repositories;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<NotificationContext>();

builder.Services.AddScoped<ICheckListOptionRepository, CheckListOptionRepository>();
builder.Services.AddScoped<ICheckListOptionService, CheckListOptionServiceAsync>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserServiceAsync>();

builder.Services.AddScoped<ICheckListRepositoryAsync, CheckListRepository>();
builder.Services.AddScoped<ICheckListServiceAsync, CheckListServiceAsync>();
builder.Services.AddScoped<ICheckListItemRepositoryAsync, CheckListItemRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContextPool<ExcContext>(options =>
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");
logger.LogInformation("Application started!");
logger.LogInformation("DefaultConnection: " + builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _Db = scope.ServiceProvider.GetRequiredService<ExcContext>();
        if (_Db != null)
        {
            if (_Db.Database.GetPendingMigrations().Any())
            {
                _Db.Database.Migrate();
            }
        }
    }
}