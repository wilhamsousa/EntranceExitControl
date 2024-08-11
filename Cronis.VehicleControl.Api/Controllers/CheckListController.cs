using Azure;
using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Model.Interfaces;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class CheckListController : MyControllerBase
    {

        private readonly ILogger<CheckListController> _logger;
        private readonly ICheckListApplication _CheckListApplication;

        public CheckListController(
            NotificationContext notificationContext, 
            ILogger<CheckListController> logger, 
            ICheckListApplication CheckListApplication)
            : base(notificationContext)
        {
            _logger = logger;
            _CheckListApplication = CheckListApplication;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var response = await _CheckListApplication.GetAsync(id);
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
                var response = await _CheckListApplication.GetAsync();
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("create")]
        public virtual async Task<ActionResult> Create(CheckListCreateDTO param)
        {
            try
            {
                AddNotifications(param.Validate());
                if (param.Invalid)
                    return CreateResult();

                var response = await _CheckListApplication.CreateAsync(param);
                return CreateResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("approve-item")]
        public virtual async Task<ActionResult> ApproveItem(CheckListItemUpdateDTO param)
        {
            try
            {
                await _CheckListApplication.ApproveItem(param);
                return CreateResult();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("reprove-item")]
        public virtual async Task<ActionResult> ReproveItem(CheckListItemUpdateDTO param)
        {
            try
            {
                await _CheckListApplication.ReproveItem(param);
                return CreateResult();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
