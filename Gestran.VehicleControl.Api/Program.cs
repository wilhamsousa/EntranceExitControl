using Gestran.VehicleControl.Api.Controllers.Notification;
using Gestran.VehicleControl.Application;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Repository;
using Gestran.VehicleControl.Infra.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<NotificationContext>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemApplication, ItemApplication>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();


builder.Services
    .AddControllers();
    //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Item>());

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