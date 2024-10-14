using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Model.Interfaces
{
    public interface ICheckListOptionRepository : IRepositoryBase<CheckListOption>
    {
        Task<CheckListOption> GetByNameAsync(string name);
    }
}
