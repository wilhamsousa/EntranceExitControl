using Gestran.VehicleControl.Domain.Model.Entity;

namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface ICheckListRepository : IBaseRepository<CheckList>
    {
        Task<List<CheckList>> GetCheckListAsync();
        Task<CheckList> GetCheckListAsync(Guid id);
        
    }
}
