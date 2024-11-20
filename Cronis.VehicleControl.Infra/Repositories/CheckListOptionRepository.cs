using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Base;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories
{
    public class CheckListOptionRepository : RepositoryBaseAsync<CheckListOption>, ICheckListOptionRepository
    {
        public CheckListOptionRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public Task<CheckListOption> GetByNameAsync(string name) =>
            _context.CheckListOption
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();
    }
}
