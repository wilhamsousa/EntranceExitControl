using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface IUserApplication
    {
        Task<User> GetAsync(Guid id);
        Task<List<User>> GetAsync();
        Task<User> Createsync(User entity);
        Task<User> CreateOrUpdateAsync(UserDTO entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(User entity);
        Task DeleteAsync(Guid id);
    }
}
