﻿using FluentValidation.Results;
using Gestran.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class MyControllerBase: ControllerBase
    {
        private readonly ValidationResult _validationResult = new ValidationResult();
        private readonly NotificationContext _notificationContext;

        protected MyControllerBase(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected ActionResult CreateResult(object responseObject) =>
            responseObject == null ? NotFound("Registro não encontrado") : Ok(responseObject);

        protected ActionResult CreateResult(IEnumerable<object> responseObject) =>
            responseObject == null || !responseObject.Any() ? NotFound("Registro não encontrado") : Ok(responseObject);

        protected ActionResult CreateResult() => Ok();

        protected void AddValidationFailure(string message)
        {
            _validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = message });
            _notificationContext.AddNotifications(_validationResult);
        }

        protected void AddNotifications(ValidationResult validationResult)
        {
            if (validationResult != null && validationResult.Errors.Any())
                _notificationContext.AddNotifications(validationResult);
        }
    }
}
