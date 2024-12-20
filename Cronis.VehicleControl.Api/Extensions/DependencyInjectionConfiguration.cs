using Cronis.VehicleControl.Application.Services;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Repositories;
using Hellang.Middleware.ProblemDetails;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static partial class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();

            services.AddScoped<ICheckListOptionRepositoryAsync, CheckListOptionRepository>();
            services.AddScoped<ICheckListOptionServiceAsync, CheckListOptionServiceAsync>();

            services.AddScoped<IUserRepositoryAsync, UserRepository>();
            services.AddScoped<IUserServiceAsync, UserServiceAsync>();

            services.AddScoped<ICheckListRepositoryAsync, CheckListRepository>();
            services.AddScoped<ICheckListServiceAsync, CheckListServiceAsync>();
            services.AddScoped<ICheckListItemRepositoryAsync, CheckListItemRepository>();
        }
    }
}
