using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Enums;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Gestran.VehicleControl.Infra.Repositories.Context.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class CheckListRepository : BaseRepository<CheckList>, ICheckListRepository
    {
        public CheckListRepository(ExcContext context, NotificationContext notificationContext) : base(context, notificationContext)
        {
        }

        public async Task<List<CheckList>> GetCheckListAsync()
        {
            var checkList = await _context.CheckList.ToListAsync();
            var checkListItem = await _context.CheckListItem
                .Include(x => x.Item)
                .ToListAsync();

            foreach (var item in checkList)
                item.CheckListItem = checkListItem.Where(x => x.CheckListId == item.Id).ToList();

            return checkList;
        }

        public async Task<CheckList> GetCheckListAsync(Guid id)
        {
            var checkList = await _context.CheckList.Where(x => x.Id == id).SingleOrDefaultAsync();
            var checkListItem = await _context.CheckListItem
                .Include(x => x.Item)
                .Where(x => x.CheckListId == id)
                .ToListAsync();

            checkList.CheckListItem = checkListItem;

            return checkList;
        }

        public async Task<CheckList> GetStartedByVehiclePlate(string vehiclePlate) =>
            await _context.CheckList
                .Where(x => x.VehiclePlate == vehiclePlate)
                .Where(x => x.Status == CheckListStatus.Started)
                .SingleOrDefaultAsync();

        public override Dictionary<string, string> MessageErrors()
        {
            return new Dictionary<string, string>
            {
                { CheckListIndexes.VehiclePlateStartDateTime, "Já existe um checklist para esta placa e horário." },
                { CheckListIndexes.CheckListUser, "Usuário não cadastrado." }
            };
        }
    }
}
