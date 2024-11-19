using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Enums;
using Cronis.VehicleControl.Domain.Notification;
using Cronis.VehicleControl.Infra.Base;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Cronis.VehicleControl.Infra.Repositories
{
    public class CheckListRepository : RepositoryBaseAsync<CheckList>, ICheckListRepositoryAsync
    {
        public CheckListRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public async Task<List<CheckList>> GetCheckListAsync()
        {
            var checkList = await _context.CheckList
                .ToListAsync();

            var checkListItem = await _context.CheckListItem
                .Include(x => x.CheckListOption)
                .ToListAsync();

            foreach (var item in checkList)
                item.CheckListItems = checkListItem.Where(x => x.CheckListId == item.Id).ToList();

            return checkList;
        }

        public async Task<CheckList> GetCheckListAsync(Guid id)
        {
            var checkList = await _context.CheckList.Where(x => x.Id == id).SingleOrDefaultAsync();
            var checkListItem = await _context.CheckListItem
                .Include(x => x.CheckListOption)
                .Where(x => x.CheckListId == id)
                .ToListAsync();

            checkList.CheckListItems = checkListItem;

            return checkList;
        }

        public async Task<CheckList> GetStartedByVehiclePlate(string vehiclePlate) =>
            await _context.CheckList
                .Where(x => x.VehiclePlate == vehiclePlate)
                .Where(x => x.Status == CheckListStatus.Started)
                .SingleOrDefaultAsync();
    }
}
