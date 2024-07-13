using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class MyControllerBase: ControllerBase
    {
        protected MyControllerBase()
        {
                
        }

        protected ActionResult CreateResult(object responseObject) =>
            responseObject == null ? NotFound("Registro não encontrado") : Ok(responseObject);

        protected ActionResult CreateResult(IEnumerable<object> responseObject) =>
            responseObject == null || !responseObject.Any() ? NotFound("Registro não encontrado") : Ok(responseObject);

        protected ActionResult CreateResult() => Ok();
    }
}
