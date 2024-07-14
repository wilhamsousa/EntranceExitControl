using Gestran.VehicleControl.Api.Controllers.Base;
using Gestran.VehicleControl.Domain.Model.Entity;
using Gestran.VehicleControl.Domain.Model.Interface;

namespace Gestran.VehicleControl.Api.Controllers
{
    public class UserController : MyControllerBaseCRUD<User, IUserApplication>
    {
        public UserController(ILogger<MyControllerBaseCRUD<User, IUserApplication>> logger, IUserApplication application) : base(logger, application)
        {
        }
    }
}
