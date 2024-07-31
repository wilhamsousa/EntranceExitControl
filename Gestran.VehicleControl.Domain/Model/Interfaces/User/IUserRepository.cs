using Gestran.VehicleControl.Domain.Model.Entities;

namespace Gestran.VehicleControl.Domain.Model.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByNameAsync(string name);
    }
}
