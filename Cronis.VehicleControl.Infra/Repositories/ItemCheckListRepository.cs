using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Base;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories
{
    public class ItemCheckListRepository : BaseRepository<ItemCheckList>, IItemCheckListRepository
    {
        public ItemCheckListRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public async Task<ItemCheckList> GetByNameAsync(string name) =>
            await _context.ItemCheckList
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();
    }
}
