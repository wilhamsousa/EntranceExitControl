using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface ICheckListRepository : IRepositoryBase<CheckList>
    {
        Task<List<CheckList>> GetCheckListAsync();
        Task<CheckList> GetCheckListAsync(Guid id);

    }
}
