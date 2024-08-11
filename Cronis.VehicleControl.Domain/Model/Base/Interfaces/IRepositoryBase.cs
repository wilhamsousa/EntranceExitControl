namespace Cronis.VehicleControl.Domain.Model.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetAsync();
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Dictionary<string, string> MessageErrors();

    }
}
