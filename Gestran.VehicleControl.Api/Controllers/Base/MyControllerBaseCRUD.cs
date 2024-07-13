using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Base.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers.Base
{
    public abstract class MyControllerBaseCRUD<TEntity, TApplicationInterface> : MyControllerBase
        where TEntity : BaseEntity
        where TApplicationInterface : IBaseApplicationCRUD<TEntity>
    {
        private readonly ILogger<MyControllerBaseCRUD<TEntity, TApplicationInterface>> _logger;
        private readonly TApplicationInterface _application;

        public MyControllerBaseCRUD(ILogger<MyControllerBaseCRUD<TEntity, TApplicationInterface>> logger, TApplicationInterface application)
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
