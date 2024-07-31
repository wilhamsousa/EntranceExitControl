using Gestran.VehicleControl.Api.Controllers.Notification;
using Gestran.VehicleControl.Application;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Repositories;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<NotificationContext>();

builder.Services.AddScoped<IItemCheckListRepository, ItemCheckListRepository>();
builder.Services.AddScoped<IItemCheckListApplication, ItemCheckListApplication>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();

builder.Services.AddScoped<ICheckListRepository, CheckListRepository>();
builder.Services.AddScoped<ICheckListApplication, CheckListApplication>();
builder.Services.AddScoped<ICheckListItemRepository, CheckListItemRepository>();

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContextPool<ExcContext>(options =>
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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