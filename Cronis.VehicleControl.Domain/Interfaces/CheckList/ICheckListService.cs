using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListService
    {
        Task<CheckList> GetAsync(Guid id);
        Task<List<CheckList>> GetAsync();
        Task<CheckList> CreateAsync(CheckListCreateRequest entity);
        Task ApproveItem(CheckListItemUpdateRequest param);
        Task ReproveItem(CheckListItemUpdateRequest param);

    }
}
