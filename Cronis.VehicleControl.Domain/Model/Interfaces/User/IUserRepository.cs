using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Model.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByNameAsync(string name);
    }
}
