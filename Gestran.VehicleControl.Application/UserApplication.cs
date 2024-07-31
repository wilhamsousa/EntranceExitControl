using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
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

        private void UserNameValidation(User entity)
        {
            var user = _repository.GetByNameAsync(entity.Name);
            if (user != null);
                AddValidationFailure(UserMessage.USERNAME_ALREADY_EXISTS);
        }
    }
}
