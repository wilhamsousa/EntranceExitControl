﻿using Gestran.VehicleControl.Application.Base;
using Gestran.VehicleControl.Domain.Model.DTOs.CheckList;
using Gestran.VehicleControl.Domain.Model.Entities;
using Gestran.VehicleControl.Domain.Model.Enums;
using Gestran.VehicleControl.Domain.Model.Interfaces;
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

            CheckList? oldCheckList = GetCheckListIfExist(param.VehiclePlate);

            if (ChecklistAnotherUser(oldCheckList, param.UserId))
                return null;            

            if (oldCheckList != null)
                return oldCheckList;            
            
            var result = await _checkListRepository.CreateAsync(newCheckList); ;
            return result;
        }

        private bool ChecklistAnotherUser(CheckList? oldCheckList, Guid userId)
        {
            bool exists = (oldCheckList != null && oldCheckList.UserId != userId);
            if (exists)
                AddValidationFailure("Já existe um checklist para esta placa e outro usuário em aberto.");

            return exists;
        }

        private CheckList? GetCheckListIfExist(string vehiclePlate)
        {
            return _checkListRepository
                            .GetQueryable()
                            .Where(x => x.VehiclePlate == vehiclePlate && x.Status == CheckListStatus.Started)
                            .SingleOrDefault();
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
            var checkListItem = _checkListItemRepository.GetQueryable().Where(x => x.Id == checkListItemId).FirstOrDefault();
            if (checkListItem == null)
            {
                AddValidationFailure("Item de checklist não encontrado.");
                return;
            }

            checkListItem.SetApproved(approved);
            await _checkListItemRepository.UpdateAsync(checkListItem);
        }
    }
}
