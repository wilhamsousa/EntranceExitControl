using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repository.Context;

namespace Gestran.VehicleControl.Infra.Repository
{
    public class ItemCheckListRepository : BaseRepository<ItemCheckList>, IItemCheckListRepository
    {
        public ItemCheckListRepository(ExcContext context) : base(context)
        {
        }
    }
}
