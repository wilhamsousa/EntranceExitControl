using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
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
