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
            try
            {
                var response = await _service.GetAsync(id);
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getall")]
        public virtual async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAsync();
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public virtual async Task<ActionResult> Create(TEntity item)
        {
            try
            {
                var response = await _service.CreateAsync(item);
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update/{id}")]
        public virtual async Task<ActionResult> Update(TEntity item, Guid id)
        {
            try
            {
                item.SetId(id);
                await _service.UpdateAsync(item);
                return CreateResult();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _service.GetAsync(id);
                if (response == null)
                    return CreateResult(response);

                await _service.DeleteAsync(id);
                return CreateResult(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
