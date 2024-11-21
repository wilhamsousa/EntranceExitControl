using Cronis.VehicleControl.Application.Services;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            RegisterCheckListMap();
        }

        public static void RegisterDependencyInjections(this IServiceCollection services)
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
