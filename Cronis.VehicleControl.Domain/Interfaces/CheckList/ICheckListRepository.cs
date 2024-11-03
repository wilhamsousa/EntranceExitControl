using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListRepository : IRepositoryBase<CheckList>
    {
        Task<List<CheckList>> GetCheckListAsync();
        Task<CheckList> GetCheckListAsync(Guid id);
        Task<CheckList> GetStartedByVehiclePlate(string vehiclePlate);

    }
}
