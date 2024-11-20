using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;
using Mapster;

namespace Cronis.VehicleControl.Application.Mapping
{
    public static partial class Mapping
    {
        private static void RegisterCheckListMap() =>
            TypeAdapterConfig<CheckList, CheckListGetResponse>
                .NewConfig()
                .Map(member => member.UserName, source => source.User.Name);
    }
}
