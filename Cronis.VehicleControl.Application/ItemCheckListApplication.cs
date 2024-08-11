using Cronis.VehicleControl.Application.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application
{
    public class ItemCheckListApplication : MyApplicationBaseCRUD<ItemCheckList, IItemCheckListRepository>, IItemCheckListApplication
    {
        public ItemCheckListApplication(IItemCheckListRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }
    }
}
