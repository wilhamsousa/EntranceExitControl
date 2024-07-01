using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Base;
using Gestran.VehicleControl.Infra.Repository.Context;

namespace Gestran.VehicleControl.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ExcContext context) : base(context)
        {
        }
    }
}
