using FluentValidation.Results;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cronis.VehicleControl.Api.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MyControllerBase: ControllerBase
    {
        private readonly NotificationContext _notificationContext;

        protected MyControllerBase(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected ActionResult CreateResult(object responseObject, string errorTitle)
        {
            if (_notificationContext.HasNotifications)
            {
                var problemDetails = new ProblemDetails()
                {
                    Title = errorTitle,
                    Status = ((int)HttpStatusCode.BadRequest),
                    Detail = string.Join(",", _notificationContext.Notifications.Select(x => x.Message))
                };

                return BadRequest(problemDetails);
            }
            
            return Ok(responseObject);
        }

        //protected ActionResult CreateResult(IEnumerable<object> responseObject) =>
        //    responseObject == null || !responseObject.Any() ? NotFound("Registro não encontrado") : Ok(responseObject);

        //protected ActionResult CreateResult() => Ok();

        protected void AddValidationFailure(string message)
        {
            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = message });
            _notificationContext.AddNotifications(validationResult);
        }

        protected void AddNotifications(ValidationResult validationResult)
        {
            if (validationResult != null && validationResult.Errors.Any())
                _notificationContext.AddNotifications(validationResult);
        }

        protected bool ValidateRequest(Guid id)
        {
            bool valid = (id == null || id == Guid.Empty);
            if (!valid)
                AddValidationFailure(INVALID_ID);

            return valid;
        }

        public const string
            INVALID_ID = "Id não informado.";
    }
}
