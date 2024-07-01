using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repository.Context;

namespace Gestran.VehicleControl.Infra.Repository
{
    public class CheckListRepository : BaseRepository<CheckList>, ICheckListRepository
    {
        public CheckListRepository(ExcContext context) : base(context)
        {
        }
    }
}
