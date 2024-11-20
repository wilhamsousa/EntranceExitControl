using Microsoft.Extensions.DependencyInjection;

namespace Cronis.VehicleControl.Application.Mapping
{
    public static partial class Mapping
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            RegisterCheckListMap();
        }
    }
}
