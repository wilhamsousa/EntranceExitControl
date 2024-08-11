using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class UserController : MyControllerBaseCRUD<User, IUserApplication>
    {
        public UserController(
            NotificationContext notificationContext,
            ILogger<MyControllerBaseCRUD<User, IUserApplication>> logger, 
            IUserApplication application)
            : base(notificationContext, logger, application)
        {
        }
    }
}
