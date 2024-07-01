namespace Gestran.VehicleControl.Domain.Model.Interface
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetAsync();
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> CreateOrUpdateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Guid id);

    }
}
