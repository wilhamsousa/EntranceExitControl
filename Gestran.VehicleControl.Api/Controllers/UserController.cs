using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Api.Controllers
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
