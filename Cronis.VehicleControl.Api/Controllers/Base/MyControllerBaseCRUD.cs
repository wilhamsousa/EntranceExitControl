using Azure;
using Cronis.VehicleControl.Domain.Interfaces.Base;
using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Cronis.VehicleControl.Api.Controllers.Base
{
    public abstract class MyControllerBaseCRUD<TEntity, TServiceInterface> : MyControllerBase
        where TEntity : BaseEntity
        where TServiceInterface : IAsyncServiceCRUDBase<TEntity>
    {
        private readonly TServiceInterface _service;

        public MyControllerBaseCRUD(NotificationContext notificationContext, TServiceInterface application)
             : base(notificationContext)
        {
            _service = application;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            var response = await _service.GetAsync(id);
            return CreateResult(response, "Erro ao consultar");
        }

        [HttpGet]
        [Route("getall")]
        public virtual async Task<ActionResult> GetAll()
        {
            var response = await _service.GetAsync();
            return CreateResult(response, "Erro ao consultar todos");
        }

        [HttpPost]
        [Route("create")]
        public virtual async Task<ActionResult> Create(TEntity item)
        {
            var response = await _service.CreateAsync(item);
            return CreateResult(response, "Erro ao criar registro");
        }

        [HttpPost]
        [Route("update/{id}")]
        public virtual async Task<ActionResult> Update(TEntity item, Guid id)
        {
            item.SetId(id);
            await _service.UpdateAsync(item);
            return CreateResult(null, "Erro ao atualizar registro");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var response = await _service.GetAsync(id);
            if (response == null)
            {
                AddValidationFailure("Registro não encontrado para excluir.");
                return CreateResult(null, "Erro ao excluir registro");
            }

            await _service.DeleteAsync(id);
            return CreateResult(id, "Erro ao excluir registro");
        }
    }
}
