using FluentValidation.Results;
using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Enum;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class CheckListApplication : ICheckListApplication
    {
        private readonly ICheckListRepository _checkListRepository;
        private readonly ICheckListItemRepository _checkListItemRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        private readonly NotificationContext _notificationContext;

        public CheckListApplication(
            ICheckListRepository checkListRepository,
            ICheckListItemRepository checkListItemRepository,
            IUserRepository userRepository,
            IItemRepository itemRepository,
            NotificationContext notificationContext)
        {
            _checkListRepository = checkListRepository;
            _checkListItemRepository = checkListItemRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _notificationContext = notificationContext;
        }        

        public async Task<CheckList> CreateAsync(CheckListCreateDTO param)
        {
            var items = await _itemRepository.GetAsync();
            
            var newCheckList = new CheckList(param.UserId, param.VehiclePlate, items);
            if (newCheckList.Invalid)
            {
                _notificationContext.AddNotifications(newCheckList.ValidationResult);
                return null;
            }

            var oldCheckList = _checkListRepository.GetQueryable().Where(x => x.VehiclePlate == param.VehiclePlate && x.Status == CheckListStatus.Started).SingleOrDefault();

            if (oldCheckList == null)
            {
                var user = await _userRepository.GetAsync(param.UserId);

                if (user == null)
                {
                    newCheckList.SetUserNotFound();
                    _notificationContext.AddNotifications(newCheckList.ValidationResult);
                    return null;
                }

                return await _checkListRepository.CreateAsync(newCheckList);
            }

            if (oldCheckList.UserId != param.UserId)
            {
                oldCheckList.SetDuplicated();
                _notificationContext.AddNotifications(oldCheckList.ValidationResult);
                return null;
            }

            return oldCheckList;
        }

        public async Task<CheckList> GetAsync(Guid id)
        {
            return await _checkListRepository.GetCheckListAsync(id);
        }

        public async Task<List<CheckList>> GetAsync()
        {
            return await _checkListRepository.GetCheckListAsync();
        }

        public async Task AproveItem(Guid checkListItemId, bool approved)
        {
            if (checkListItemId == Guid.Empty || checkListItemId == null)
            {
                ValidationResult validationResult = new ValidationResult();
                validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = "Id não informado." });
                _notificationContext.AddNotifications(validationResult);
                return;
            }

            var checkListItem = _checkListItemRepository.GetQueryable().Where(x => x.Id == checkListItemId).FirstOrDefault();

            if (checkListItem == null)
            {
                ValidationResult validationResult = new ValidationResult();
                validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = "Item de checklist não encontrado." });
                _notificationContext.AddNotifications(validationResult);
                return;
            }

            checkListItem.Approved = approved;
            await _checkListItemRepository.UpdateAsync(checkListItem);
        }
    }
}
