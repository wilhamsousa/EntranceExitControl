using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class UserApplication : MyApplicationBaseCRUD<User, IUserRepository>, IUserApplication
    {
        public UserApplication(IUserRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }
    }
}
