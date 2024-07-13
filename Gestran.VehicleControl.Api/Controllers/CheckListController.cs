using Azure;
using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : MyControllerBase
    {

        private readonly ILogger<CheckListController> _logger;
        private readonly ICheckListApplication _CheckListApplication;

        public CheckListController(ILogger<CheckListController> logger, ICheckListApplication CheckListApplication)
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
