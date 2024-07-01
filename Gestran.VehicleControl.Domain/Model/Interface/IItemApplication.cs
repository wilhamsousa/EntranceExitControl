using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface IItemApplication
    {
        Task<Item> GetAsync(Guid id);
        Task<List<Item>> GetAsync();
        Task<Item> Createsync(Item entity);
        Task<Item> CreateOrUpdateAsync(ItemDTO entity);
        Task UpdateAsync(Item entity);
        Task DeleteAsync(Item entity);
        Task DeleteAsync(Guid id);
    }
}
