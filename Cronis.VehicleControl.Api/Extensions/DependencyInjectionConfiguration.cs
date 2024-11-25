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

            services.AddScoped<ICheckListOptionRepository, CheckListOptionRepository>();
            services.AddScoped<ICheckListOptionService, CheckListOptionServiceAsync>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserServiceAsync>();

            services.AddScoped<ICheckListRepositoryAsync, CheckListRepository>();
            services.AddScoped<ICheckListServiceAsync, CheckListServiceAsync>();
            services.AddScoped<ICheckListItemRepositoryAsync, CheckListItemRepository>();
        }
    }
}
