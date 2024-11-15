using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class CheckListOptionController : MyControllerBaseCRUD<CheckListOption, ICheckListOptionService>
    {
        public CheckListOptionController(NotificationContext notificationContext, ICheckListOptionService application) : base(notificationContext, application)
        {
        }
    }
}
