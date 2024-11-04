using Cronis.VehicleControl.Application.Base;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;

namespace Cronis.VehicleControl.Application.Services
{
    public class CheckListService : MyServiceBase, ICheckListService
    {
        private readonly ICheckListRepository _checkListRepository;
        private readonly ICheckListItemRepository _checkListItemRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICheckListOptionRepository _CheckListOptionRepository;


        public CheckListService(
            NotificationContext notificationContext,
            ICheckListRepository checkListRepository,
            ICheckListItemRepository checkListItemRepository,
            IUserRepository userRepository,
            ICheckListOptionRepository checkListOptionRepository
        ) : base(notificationContext)
        {
            _checkListRepository = checkListRepository;
            _checkListItemRepository = checkListItemRepository;
            _userRepository = userRepository;
            _CheckListOptionRepository = checkListOptionRepository;
        }

        public async Task<CheckList> CreateAsync(CheckListCreateRequest param)
        {
            var items = await _CheckListOptionRepository.GetAsync();
            var newCheckList = new CheckList(param.UserId, param.VehiclePlate, items);
            AddNotifications(newCheckList.ValidationResult);

            if (HasNotifications)
                return null;

            UserNotFoundValidation(param.UserId);

            if (HasNotifications)
                return null;

            CheckList? oldCheckList = await GetCheckListIfExist(param.VehiclePlate);

            ChecklistAlreadyExistsValidation(oldCheckList, param.UserId);

            if (HasNotifications)
                return null;

            if (oldCheckList != null)
                return oldCheckList;

            var result = await _checkListRepository.CreateAsync(newCheckList); ;
            return result;
        }

        private async Task UserNotFoundValidation(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);

            if (user == null)
                AddValidationFailure(CheckListMessage.CHECKLIST_USER_NOTFOUND);
        }

        private void ChecklistAlreadyExistsValidation(CheckList? oldCheckList, Guid userId)
        {
            if (oldCheckList != null && oldCheckList.UserId != userId)
                AddValidationFailure(CheckListMessage.CHECKLIST_ALREADY_EXISTS);
        }

        private async Task<CheckList?> GetCheckListIfExist(string vehiclePlate) =>
            await _checkListRepository.GetStartedByVehiclePlate(vehiclePlate);

        public async Task<CheckList> GetAsync(Guid id)
        {
            return await _checkListRepository.GetCheckListAsync(id);
        }

        public async Task<List<CheckList>> GetAsync()
        {
            return await _checkListRepository.GetCheckListAsync();
        }

        public async Task ApproveItem(CheckListItemUpdateRequest param) => AproveOrReproveItem(param, true);
        public async Task ReproveItem(CheckListItemUpdateRequest param) => AproveOrReproveItem(param, false);

        public async Task AproveOrReproveItem(CheckListItemUpdateRequest param, bool approve)
        {
            var checkListItem = await _checkListItemRepository.GetAsync(param.checkListItemId);
            CheckListItemNotFoundValidation(checkListItem);

            if (HasNotifications)
                return;

            checkListItem.SetApproved(approve);
            await _checkListItemRepository.UpdateAsync(checkListItem);
        }



        private void CheckListItemNotFoundValidation(CheckListItem? checkListItem)
        {
            if (checkListItem == null)
                AddValidationFailure(CheckListMessage.CHECKLISTITEM_NOTFOUND);
        }
    }
}
