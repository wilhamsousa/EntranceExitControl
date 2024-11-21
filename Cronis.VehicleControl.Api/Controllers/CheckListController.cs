using Cronis.VehicleControl.Api.Controllers.Base;
using Cronis.VehicleControl.Domain.Model.DTOs.CheckList;
using Cronis.VehicleControl.Domain.Notification;
using Microsoft.AspNetCore.Mvc;
using Cronis.VehicleControl.Domain.Interfaces;
using Cronis.VehicleControl.Domain.Model.Validators;

namespace Cronis.VehicleControl.Api.Controllers
{
    public class CheckListController : MyControllerBase
    {

        private readonly ILogger<CheckListController> _logger;
        private readonly ICheckListServiceAsync _checkListService;

        public CheckListController(
            NotificationContext notificationContext, 
            ILogger<CheckListController> logger, 
            ICheckListServiceAsync CheckListApplication)
            : base(notificationContext)
        {
            _logger = logger;
            _checkListService = CheckListApplication;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var response = await _checkListService.GetAsync(id);
                return CreateResult(response, "Erro");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _checkListService.GetAsync();
                return CreateResult(response.ToList(), "Erro ao consultar.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CheckListCreateRequest param)
        {
            try
            {
                var requestValidator = new CheckListCreateRequestValidator();
                var requestValidatorResult = requestValidator.Validate(param);
                if (!requestValidatorResult.IsValid)
                {
                    AddNotifications(requestValidatorResult);
                    return CreateResult(null, "Erro ao inserir registro");
                }

                var response = await _checkListService.CreateAsync(param);
                return CreateResult(response, "Erro ao inserir registro");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("approve-item")]
        public async Task<ActionResult> ApproveItem(CheckListItemUpdateRequest param)
        {
            try
            {
                await _checkListService.ApproveItemAsync(param);
                return CreateResult(null, "Erro ao aprovar item");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("reprove-item")]
        public async Task<ActionResult> ReproveItem(CheckListItemUpdateRequest param)
        {
            try
            {
                await _checkListService.ReproveItemAsync(param);
                return CreateResult(null, "Erro ao reprovar item");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
