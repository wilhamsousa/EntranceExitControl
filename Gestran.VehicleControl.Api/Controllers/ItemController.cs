using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;

namespace Gestran.VehicleControl.Api.Controllers
{
    public class ItemController : MyControllerBaseCRUD<ItemCheckList, IItemCheckListApplication>
    {
        public ItemController(ILogger<MyControllerBaseCRUD<ItemCheckList, IItemCheckListApplication>> logger, IItemCheckListApplication application) : base(logger, application)
        {
        }
    }
}
