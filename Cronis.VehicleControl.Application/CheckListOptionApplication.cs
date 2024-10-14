using Cronis.VehicleControl.Application.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application
{
    public class CheckListOptionApplication : MyApplicationBaseCRUD<CheckListOption, ICheckListOptionRepository>, Domain.Model.Interfaces.ICheckListOptionApplication
    {
        public CheckListOptionApplication(ICheckListOptionRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }

        public override async Task<CheckListOption> CreateAsync(CheckListOption entity)
        {
            checkListOptionNameValidation(entity);
            if (HasNotifications)
                return null;

            return await base.CreateAsync(entity);
        }

        private async void checkListOptionNameValidation(CheckListOption entity)
        {
            var checkListOption = await _repository.GetByNameAsync(entity.Name);
            if (checkListOption != null)
                AddValidationFailure(CheckListOptionMessage.CHECKLISTPTION_ALREADY_EXISTS);
        }
    }
}
