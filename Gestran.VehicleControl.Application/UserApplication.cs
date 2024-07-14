using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class UserApplication : BaseApplicationCRUD<User, IUserRepository>, IUserApplication
    {
        public UserApplication(IUserRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }
    }
}
