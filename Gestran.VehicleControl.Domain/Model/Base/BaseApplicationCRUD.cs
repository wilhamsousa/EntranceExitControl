using Gestran.VehicleControl.Domain.Model.Base.Interface;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Domain.Model.Base
{
    public abstract class BaseApplicationCRUD<TEntity, TRepositoryInterface> : IBaseApplicationCRUD<TEntity>
        where TEntity : BaseEntity        
        where TRepositoryInterface : IBaseRepository<TEntity>
    {
        private readonly TRepositoryInterface _repository;
        private readonly NotificationContext _notificationContext;

        public BaseApplicationCRUD(TRepositoryInterface repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                var response = await _repository.CreateAsync(entity);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<TEntity>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
