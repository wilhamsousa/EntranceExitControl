using Gestran.VehicleControl.Domain.Model.DTO;
using Gestran.VehicleControl.Domain.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserApplication _UserApplication;

        public UserController(ILogger<UserController> logger, IUserApplication UserApplication)
        {
            _logger = logger;
            _UserApplication = UserApplication;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var response = await _UserApplication.GetAsync(id);
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
                var response = await _UserApplication.GetAsync();
                if (response == null || response.Count == 0)
                    return NotFound("Registro não encontrado");

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
                var response = await _UserApplication.GetAsync(id);
                if (response == null)
                    return NotFound("Registro não encontrado");

                await _UserApplication.DeleteAsync(id);
                return Ok("Registro excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
