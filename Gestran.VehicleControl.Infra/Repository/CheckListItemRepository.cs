using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestran.VehicleControl.Infra.Repository
{
    public class CheckListItemRepository : BaseRepository<CheckListItem>, ICheckListItemRepository
    {
        public CheckListItemRepository(ExcContext context) : base(context)
        {
        }
    }
}
