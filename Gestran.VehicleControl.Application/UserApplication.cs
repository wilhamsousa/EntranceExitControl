using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class UserApplication: IUserApplication
    {
        private readonly IUserRepository _UserRepository;
        private readonly NotificationContext _notificationContext;

        public UserApplication(IUserRepository UserRepository, NotificationContext notificationContext)
        {
            _UserRepository = UserRepository;
            _notificationContext = notificationContext;
        }

        public async Task<User> Createsync(User entity)
        {
            try
            {
                var response = await _UserRepository.CreateAsync(entity);
                return response;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<User> CreateOrUpdateAsync(UserDTO param)
        {            
            var user = new User(param.Id, param.Name);
            if (user.Invalid)
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return null;
            }

            if (param.Id == Guid.Empty || param.Id == null)
            {
                var alreadyExists = _UserRepository.GetQueryable().Any(x => x.Name == param.Name);

                if (alreadyExists)
                {
                    user.SetDuplicated();
                    _notificationContext.AddNotifications(user.ValidationResult);
                    return null;
                }
            }


            return await _UserRepository.CreateOrUpdateAsync(user);
        }

        public async Task DeleteAsync(User entity)
        {
            await _UserRepository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _UserRepository.DeleteAsync(id);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _UserRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAsync()
        {
            return await _UserRepository.GetAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            await _UserRepository.UpdateAsync(entity);
        }
    }
}
