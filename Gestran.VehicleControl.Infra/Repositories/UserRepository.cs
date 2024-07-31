using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public User GetByNameAsync(string name) => _context.User.Where(x => x.Name == name).SingleOrDefault();
    }
}
