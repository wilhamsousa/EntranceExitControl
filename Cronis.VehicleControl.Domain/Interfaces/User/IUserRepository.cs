using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByNameAsync(string name);
    }
}
