using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Application;
using Gestran.VehicleControl.Domain.Model.Base.Interface;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;
using Gestran.VehicleControl.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.VehicleControl.Api.Controllers
{
    public class ItemController : MyControllerBaseCRUD<Item, IItemApplication>
    {
        public ItemController(ILogger<MyControllerBaseCRUD<Item, IItemApplication>> logger, IItemApplication application) : base(logger, application)
        {
        }
    }
}
