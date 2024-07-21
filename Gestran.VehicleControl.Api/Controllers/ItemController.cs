using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Api.Controllers
{
    public class ItemController : MyControllerBaseCRUD<ItemCheckList, IItemCheckListApplication>
    {
        public ItemController(
            NotificationContext notificationContext,
            ILogger<MyControllerBaseCRUD<ItemCheckList, IItemCheckListApplication>> logger, 
            IItemCheckListApplication application)
            : base(notificationContext, logger, application)
        {
        }
    }
}
