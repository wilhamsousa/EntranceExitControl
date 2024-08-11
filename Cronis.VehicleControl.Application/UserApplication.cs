using Cronis.VehicleControl.Application.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application
{
    public class UserApplication : MyApplicationBaseCRUD<User, IUserRepository>, IUserApplication
    {
        public UserApplication(IUserRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }

        public override async Task<User> CreateAsync(User entity)
        {
            UserNameValidation(entity);
            if (HasNotifications)
                return null;

            return await base.CreateAsync(entity);
        }

        private async void UserNameValidation(User entity)
        {
            var user = await _repository.GetByNameAsync(entity.Name);
            if (user != null)
                AddValidationFailure(UserMessage.USERNAME_ALREADY_EXISTS);
        }
    }
}
