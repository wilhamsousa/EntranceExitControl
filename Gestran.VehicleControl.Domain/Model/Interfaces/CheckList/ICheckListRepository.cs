using Gestran.VehicleControl.Domain.Model.Entities;

namespace Gestran.VehicleControl.Domain.Model.Interfaces
{
    public interface ICheckListRepository : IRepositoryBase<CheckList>
    {
        Task<List<CheckList>> GetCheckListAsync();
        Task<CheckList> GetCheckListAsync(Guid id);
        Task<CheckList> GetStartedByVehiclePlate(string vehiclePlate);

    }
}
