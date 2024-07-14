using Gestran.VehicleControl.Domain.Model.DTO.CheckList;
using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface ICheckListApplication
    {
        Task<CheckList> GetAsync(Guid id);
        Task<List<CheckList>> GetAsync();
        Task<CheckList> CreateAsync(CheckListCreateDTO entity);
        Task AproveItem(Guid checkListItemId, bool approved);

    }
}
