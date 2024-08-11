using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
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
