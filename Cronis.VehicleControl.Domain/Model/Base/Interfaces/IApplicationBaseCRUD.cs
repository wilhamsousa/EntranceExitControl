namespace Cronis.VehicleControl.Domain.Model.Base.Interfacess
{
    public interface IApplicationBaseCRUD<TEntity>
    {
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
