using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListServiceAsync
    {
        Task<CheckListGetResponse> GetAsync(Guid id);
        Task<IEnumerable<CheckListGetAllResponse>> GetAsync();
        Task<CheckList> CreateAsync(CheckListCreateRequest entity);
        Task ApproveItemAsync(CheckListItemUpdateRequest param);
        Task ReproveItemAsync(CheckListItemUpdateRequest param);

    }
}
