using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Base.Interface;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application.Base
{
    public abstract class MyApplicationBaseCRUD<TEntity, TRepositoryInterface> : MyApplicationBase, IApplicationBaseCRUD<TEntity>
        where TEntity : BaseEntity        
        where TRepositoryInterface : IRepositoryBase<TEntity>
    {
        private readonly TRepositoryInterface _repository;

        public MyApplicationBaseCRUD(TRepositoryInterface repository, NotificationContext notificationContext) : 
            base(notificationContext)
        {
            _repository = repository;
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
