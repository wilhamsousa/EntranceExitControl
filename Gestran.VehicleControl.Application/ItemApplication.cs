using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Domain.Notification;

namespace Gestran.VehicleControl.Application
{
    public class ItemApplication: IItemApplication
    {
        private readonly IItemRepository _itemRepository;
        private readonly NotificationContext _notificationContext;

        public ItemApplication(IItemRepository itemRepository, NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Item> Createsync(Item entity)
        {
            try
            {
                var response = await _itemRepository.CreateAsync(entity);
                return response;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<Item> CreateOrUpdateAsync(ItemDTO param)
        {            
            var item = new Item(param.Id, param.Name, param.Note);
            if (item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            if (param.Id == Guid.Empty || param.Id == null)
            {
                var alreadyExists = _itemRepository.GetQueryable().Any(x => x.Name == param.Name);

                if (alreadyExists)
                {
                    item.SetDuplicated();
                    _notificationContext.AddNotifications(item.ValidationResult);
                    return null;
                }
            }


            return await _itemRepository.CreateOrUpdateAsync(item);
        }

        public async Task DeleteAsync(Item entity)
        {
            await _itemRepository.DeleteAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _itemRepository.DeleteAsync(id);
        }

        public async Task<Item> GetAsync(Guid id)
        {
            return await _itemRepository.GetAsync(id);
        }

        public async Task<List<Item>> GetAsync()
        {
            return await _itemRepository.GetAsync();
        }

        public async Task UpdateAsync(Item entity)
        {
            await _itemRepository.UpdateAsync(entity);
        }
    }
}
