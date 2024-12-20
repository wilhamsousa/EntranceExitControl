using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class UserController : MyControllerBaseCRUD<User, IUserServiceAsync>
    {
        public UserController(NotificationContext notificationContext, IUserServiceAsync application) : base(notificationContext, application)
        {
        }
    }
}
