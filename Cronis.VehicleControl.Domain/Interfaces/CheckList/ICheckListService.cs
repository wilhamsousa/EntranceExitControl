using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListService
    {
        Task<CheckList> GetAsync(Guid id);
        Task<List<CheckList>> GetAsync();
        Task<CheckList> CreateAsync(CheckListCreateDTO entity);
        Task ApproveItem(CheckListItemUpdateDTO param);
        Task ReproveItem(CheckListItemUpdateDTO param);

    }
}
