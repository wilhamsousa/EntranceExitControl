using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Model.Base.Interfacess;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Cronis.VehicleControl.Api.Controllers.Base
{
    public abstract class MyControllerBaseCRUD<TEntity, TApplicationInterface> : MyControllerBase
        where TEntity : BaseEntity
        where TApplicationInterface : IApplicationBaseCRUD<TEntity>
    {
        private readonly ILogger<MyControllerBaseCRUD<TEntity, TApplicationInterface>> _logger;
        private readonly TApplicationInterface _application;

        public MyControllerBaseCRUD(NotificationContext notificationContext, ILogger<MyControllerBaseCRUD<TEntity, TApplicationInterface>> logger, TApplicationInterface application)
             : base(notificationContext)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var response = await _application.GetAsync(id);
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
                var response = await _application.GetAsync();
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
                var response = await _application.CreateAsync(item);
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
                await _application.UpdateAsync(item);
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
                var response = await _application.GetAsync(id);
                if (response == null)
                    return CreateResult(response);

                await _application.DeleteAsync(id);
                return CreateResult(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
