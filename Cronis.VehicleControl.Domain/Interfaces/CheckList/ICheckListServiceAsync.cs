using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListServiceAsync
    {
        Task<CheckListGetResponse> GetAsync(Guid id);
        Task<List<CheckListGetResponse>> GetAsync();
        Task<CheckList> CreateAsync(CheckListCreateRequest entity);
        Task ApproveItem(CheckListItemUpdateRequest param);
        Task ReproveItem(CheckListItemUpdateRequest param);

    }
}
