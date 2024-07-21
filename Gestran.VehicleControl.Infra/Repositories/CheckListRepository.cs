using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class CheckListRepository : BaseRepository<CheckList>, ICheckListRepository
    {
        public CheckListRepository(ExcContext context) : base(context)
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
    }
}
