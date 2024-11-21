using Hellang.Middleware.ProblemDetails;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static partial class MappingConfiguration
    {
        public static void AddMapping()
        {
            RegisterCheckListMap();
        }
    }
}
