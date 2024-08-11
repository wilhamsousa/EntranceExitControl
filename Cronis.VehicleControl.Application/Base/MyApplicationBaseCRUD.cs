using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Model.Base.Interfacess;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application.Base
{
    public abstract class MyApplicationBaseCRUD<TEntity, TRepositoryInterface> : MyApplicationBase, IApplicationBaseCRUD<TEntity>
        where TEntity : BaseEntity
        where TRepositoryInterface : IRepositoryBase<TEntity>
    {
        protected readonly TRepositoryInterface _repository;

        public MyApplicationBaseCRUD(TRepositoryInterface repository, NotificationContext notificationContext) :
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
