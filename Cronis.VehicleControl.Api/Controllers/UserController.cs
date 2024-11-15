using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class UserController : MyControllerBaseCRUD<User, IUserService>
    {
        public UserController(NotificationContext notificationContext, IUserService application) : base(notificationContext, application)
        {
        }
    }
}
