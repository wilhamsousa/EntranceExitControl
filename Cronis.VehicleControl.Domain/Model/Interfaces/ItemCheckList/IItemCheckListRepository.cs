using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Model.Interfaces
{
    public interface IItemCheckListRepository : IRepositoryBase<ItemCheckList>
    {
        Task<ItemCheckList> GetByNameAsync(string name);
    }
}
