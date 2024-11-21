using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;
using Mapster;

namespace Cronis.VehicleControl.Api.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        private static void RegisterCheckListMap()
        {
            TypeAdapterConfig<CheckList, CheckListGetAllResponse>
                .NewConfig()
                .Map(destiny => destiny.UserName, source => source.User.Name);

            TypeAdapterConfig<CheckListItem, CheckListItemGetResponse>
                .NewConfig()
                .Map(destiny => destiny.Name, source => source.CheckListOption.Name)
                .Map(destiny => destiny.Note, source => source.CheckListOption.Note);
        }
    }
}
