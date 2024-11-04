using Microsoft.AspNetCore.Mvc;

namespace Cronis.VehicleControl.Api.Controllers
{
    public interface IControllerCRUD<TCreateRequestDTO, TUpdateRequestDTO>
    {
        Task<ActionResult> Get(Guid id);
        Task<ActionResult> GetAll();
        Task<ActionResult> Create(TCreateRequestDTO item);
        Task<ActionResult> Update(TUpdateRequestDTO item);
        Task<ActionResult> Delete(Guid id);
    }
}
