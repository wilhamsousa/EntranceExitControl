using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class CheckListApplication: ICheckListApplication
    {
        private readonly ICheckListRepository _CheckListRepository;
        private readonly NotificationContext _notificationContext;

        public CheckListApplication(ICheckListRepository CheckListRepository, NotificationContext notificationContext)
        {
            _CheckListRepository = CheckListRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CheckList> Createsync(CheckList entity)
        {
            try
            {
                var response = await _CheckListRepository.CreateAsync(entity);
                return response;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<CheckList> CreateOrUpdateAsync(CheckListDTO param)
        {            
            var CheckList = new CheckList(param.Id, param.VehiclePlate);
            if (CheckList.Invalid)
            {
                _notificationContext.AddNotifications(CheckList.ValidationResult);
                return null;
            }

            if (param.Id == Guid.Empty || param.Id == null)
            {
                var alreadyExists = _CheckListRepository.GetQueryable().Any(x => x.VehiclePlate == param.VehiclePlate);

                if (alreadyExists)
                {
                    CheckList.SetDuplicated();
                    _notificationContext.AddNotifications(CheckList.ValidationResult);
                }
            }

            return await _CheckListRepository.CreateOrUpdateAsync(CheckList);
        }

        public async Task DeleteAsync(CheckList entity)
        {
            await _CheckListRepository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _CheckListRepository.DeleteAsync(id);
        }

        public async Task<CheckList> GetAsync(Guid id)
        {
            return await _CheckListRepository.GetAsync(id);
        }

        public async Task<List<CheckList>> GetAsync()
        {
            return await _CheckListRepository.GetAsync();
        }

        public async Task UpdateAsync(CheckList entity)
        {
            await _CheckListRepository.UpdateAsync(entity);
        }
    }
}
