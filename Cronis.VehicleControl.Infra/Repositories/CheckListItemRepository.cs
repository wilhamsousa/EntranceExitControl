using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Base;
using Cronis.VehicleControl.Infra.Repositories.Context;

namespace Cronis.VehicleControl.Infra.Repositories
{
    public class CheckListItemRepository : BaseRepository<CheckListItem>, ICheckListItemRepository
    {
        public CheckListItemRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }
    }
}
