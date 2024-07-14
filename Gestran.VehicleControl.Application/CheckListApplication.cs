using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.DTO.CheckList;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Enum;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class CheckListApplication : MyApplicationBase, ICheckListApplication
    {
        private readonly ICheckListRepository _checkListRepository;
        private readonly ICheckListItemRepository _checkListItemRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemCheckListRepository _itemCheckListRepository;
        

        public CheckListApplication(
            NotificationContext notificationContext,
            ICheckListRepository checkListRepository,
            ICheckListItemRepository checkListItemRepository,
            IUserRepository userRepository,
            IItemCheckListRepository itemCheckListRepository
        ) : base(notificationContext)
        {
            _checkListRepository = checkListRepository;
            _checkListItemRepository = checkListItemRepository;
            _userRepository = userRepository;
            _itemCheckListRepository = itemCheckListRepository;            
        }        

        public async Task<CheckList> CreateAsync(CheckListCreateDTO param)
        {
            var items = await _itemCheckListRepository.GetAsync();            
            var newCheckList = new CheckList(param.UserId, param.VehiclePlate, items);
            AddNotifications(newCheckList.ValidationResult);
            if (newCheckList.Invalid)
                return null;

            var oldCheckList = _checkListRepository
                .GetQueryable()
                .Where(x => x.VehiclePlate == param.VehiclePlate && x.Status == CheckListStatus.Started)
                .SingleOrDefault();

            if (oldCheckList == null)
            {
                var user = await _userRepository.GetAsync(param.UserId);

                if (user == null)
                {
                    AddValidationFailure("Usuário não cadastrado.");
                    return null;
                }

                return await _checkListRepository.CreateAsync(newCheckList);
            }

            if (oldCheckList.UserId != param.UserId)
            {
                AddValidationFailure("Já existe um checklist para este usuário em aberto.");
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
                AddValidationFailure("Id não informado.");
                return;
            }

            var checkListItem = _checkListItemRepository.GetQueryable().Where(x => x.Id == checkListItemId).FirstOrDefault();
            if (checkListItem == null)
            {
                AddValidationFailure("Item de checklist não encontrado.");
                return;
            }

            checkListItem.Approved = approved;
            await _checkListItemRepository.UpdateAsync(checkListItem);
        }
    }
}
