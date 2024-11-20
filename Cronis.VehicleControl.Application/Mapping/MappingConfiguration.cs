using Microsoft.Extensions.DependencyInjection;

namespace Cronis.VehicleControl.Application.Mapping
{
    public static partial class MappingConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            RegisterCheckListMap();
        }
    }
}
