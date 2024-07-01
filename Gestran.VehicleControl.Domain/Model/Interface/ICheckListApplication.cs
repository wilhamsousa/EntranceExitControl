using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface ICheckListApplication
    {
        Task<CheckList> GetAsync(Guid id);
        Task<List<CheckList>> GetAsync();
        Task<CheckList> Createsync(CheckList entity);
        Task<CheckList> CreateOrUpdateAsync(CheckListDTO entity);
        Task UpdateAsync(CheckList entity);
        Task DeleteAsync(CheckList entity);
        Task DeleteAsync(Guid id);
    }
}
