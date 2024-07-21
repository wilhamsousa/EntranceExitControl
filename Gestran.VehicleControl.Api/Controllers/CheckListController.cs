using Azure;
using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.DTOs.CheckList;
using Gestran.VehicleControl.Domain.Model.Interfaces;
using Gestran.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers
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
        [Route("aprove-item")]
        public virtual async Task<ActionResult> AproveItem(CheckListItemUpdateDTO param)
        {
            try
            {
                await _CheckListApplication.AproveItem(param.itemId, true);
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
                await _CheckListApplication.AproveItem(param.itemId, false);
                return CreateResult();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
