using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public async Task<User> GetByNameAsync(string name) => 
            await _context.User
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();
    }
}
