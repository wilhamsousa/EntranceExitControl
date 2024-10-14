using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class CheckListOptionController : MyControllerBaseCRUD<CheckListOption, ICheckListOptionApplication>
    {
        public CheckListOptionController(
            NotificationContext notificationContext,
            ILogger<MyControllerBaseCRUD<CheckListOption, ICheckListOptionApplication>> logger, 
            ICheckListOptionApplication application)
            : base(notificationContext, logger, application)
        {
        }
    }
}
