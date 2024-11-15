using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application.Base
{
    public abstract class ServiceCRUDBaseAsync<TEntity, TRepositoryInterface> : ServiceBase, IAsyncServiceCRUDBase<TEntity>
        where TEntity : BaseEntity
        where TRepositoryInterface : IAsyncRepositoryBase<TEntity>
    {
        protected readonly TRepositoryInterface _repository;

        public ServiceCRUDBaseAsync(TRepositoryInterface repository, NotificationContext notificationContext) :
            base(notificationContext)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var response = await _repository.CreateAsync(entity);
            return response;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
