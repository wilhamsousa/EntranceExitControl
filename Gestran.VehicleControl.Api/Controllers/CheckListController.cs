using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : ControllerBase
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
                if (response == null) 
                    return NotFound("Registro não encontrado");

                return Ok(response);
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
                if (response == null || response.Count == 0)
                    return NotFound("Registro não encontrado");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("persist")]
        public virtual async Task<ActionResult> Persist(CheckListDTO CheckList)
        {
            try
            {
                var response = await _CheckListApplication.CreateOrUpdateAsync(CheckList);
                
                return Ok(response);
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
                var response = await _CheckListApplication.GetAsync(id);
                if (response == null)
                    return NotFound("Registro não encontrado");

                await _CheckListApplication.DeleteAsync(id);
                return Ok("Registro excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
