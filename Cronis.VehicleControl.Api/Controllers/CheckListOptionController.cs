using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.DTOs;
using Cronis.VehicleControl.Domain.Model.Entities;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class CheckListOptionController : MyControllerBase, IControllerCRUD<CheckListOptionCreateRequest, CheckListOptionUpdateRequest>
    {
        private readonly ICheckListOptionService _service;
        private readonly ILogger<CheckListOptionController> _logger;

        public CheckListOptionController(
            NotificationContext notificationContext,
            ILogger<CheckListOptionController> logger, 
            ICheckListOptionService service) : base(notificationContext)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            try
            {
                if (!ValidateRequest(id))
                    return CreateResult();

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
        public virtual async Task<ActionResult> Create(CheckListOptionCreateRequest item)
        {
            try
            {
                var entity = (CheckListOption)item;
                var response = await _service.CreateAsync(entity);
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update/{id}")]
        public virtual async Task<ActionResult> Update(CheckListOptionUpdateRequest item)
        {
            try
            {
                var entity = await _service.GetAsync(item.Id);
                entity.UpdateValues(item);
                await _service.UpdateAsync(entity);
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
            if (!ValidateRequest(id))
                return CreateResult();

            try
            {
                var response = await _service.GetAsync(id);
                if (response == null)
                    return CreateResult();

                await _service.DeleteAsync(id);
                return CreateResult();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }        
    }
}
