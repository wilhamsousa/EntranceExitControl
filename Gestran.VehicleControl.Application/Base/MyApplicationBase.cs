using Gestran.VehicleControl.Domain.Notification;
using FluentValidation.Results;
using FluentValidation;

namespace Gestran.VehicleControl.Application.Base
{
    public abstract class MyApplicationBase
    {
        private readonly ValidationResult _validationResult = new ValidationResult();
        private readonly NotificationContext _notificationContext;

        protected MyApplicationBase(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected void AddValidationFailure(string message)
        {
            _validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = message });
            _notificationContext.AddNotifications(_validationResult);
        }

        protected void AddNotifications(ValidationResult validationResult)
        {
            if (validationResult != null)
                _notificationContext.AddNotifications(validationResult);
        }
    }
}
