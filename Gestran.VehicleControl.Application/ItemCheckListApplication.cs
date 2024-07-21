using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class ItemCheckListApplication : MyApplicationBaseCRUD<ItemCheckList, IItemCheckListRepository>, IItemCheckListApplication
    {
        public ItemCheckListApplication(IItemCheckListRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }
    }
}
