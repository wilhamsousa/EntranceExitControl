using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repositories.Context;

namespace Gestran.VehicleControl.Infra.Repositories
{
    public class CheckListItemRepository : BaseRepository<CheckListItem>, ICheckListItemRepository
    {
        public CheckListItemRepository(ExcContext context) : base(context)
        {
        }
    }
}
