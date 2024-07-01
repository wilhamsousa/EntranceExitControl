using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repository.Context;

namespace Gestran.VehicleControl.Infra.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ExcContext context) : base(context)
        {
        }
    }
}
