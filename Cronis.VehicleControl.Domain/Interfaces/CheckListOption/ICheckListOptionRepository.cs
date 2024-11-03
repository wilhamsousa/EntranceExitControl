using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListOptionRepository : IRepositoryBase<CheckListOption>
    {
        Task<CheckListOption> GetByNameAsync(string name);
    }
}
