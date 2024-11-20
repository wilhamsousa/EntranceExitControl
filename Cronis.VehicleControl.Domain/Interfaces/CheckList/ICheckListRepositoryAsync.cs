using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Entities;

namespace Cronis.VehicleControl.Domain.Interfaces
{
    public interface ICheckListRepositoryAsync : IAsyncRepositoryBase<CheckList>
    {
        Task<List<CheckList>> GetCheckListAsync();
        Task<CheckList> GetCheckListAsync(Guid id);
        Task<CheckList> GetStartedByVehiclePlateAsync(string vehiclePlate);

    }
}
