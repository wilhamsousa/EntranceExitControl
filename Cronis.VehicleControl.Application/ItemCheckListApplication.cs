using Cronis.VehicleControl.Application.Base;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application
{
    public class ItemCheckListApplication : MyApplicationBaseCRUD<ItemCheckList, IItemCheckListRepository>, IItemCheckListApplication
    {
        public ItemCheckListApplication(IItemCheckListRepository repository, NotificationContext notificationContext) : base(repository, notificationContext)
        {
        }

        public override async Task<ItemCheckList> CreateAsync(ItemCheckList entity)
        {
            ItemCheckListNameValidation(entity);
            if (HasNotifications)
                return null;

            return await base.CreateAsync(entity);
        }

        private async void ItemCheckListNameValidation(ItemCheckList entity)
        {
            var ItemCheckList = await _repository.GetByNameAsync(entity.Name);
            if (ItemCheckList != null)
                AddValidationFailure(ItemCheckListMessage.ITEMCHECKLIST_ALREADY_EXISTS);
        }
    }
}
