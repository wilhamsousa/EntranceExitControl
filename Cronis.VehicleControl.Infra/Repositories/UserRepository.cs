using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Base;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories
{
    public class UserRepository : RepositoryBaseAsync<User>, IUserRepositoryAsync
    {
        public UserRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public Task<User> GetByNameAsync(string name) => 
            _context.User
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();
    }
}
