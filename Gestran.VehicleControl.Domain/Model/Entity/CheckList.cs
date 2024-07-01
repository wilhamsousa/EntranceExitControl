using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class CheckList : BaseEntity
    {
        public string VehiclePlate { get; set; }

        [NotMapped]
        public bool DuplicatedPlateError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedPlateError = true;
            Validate(this, new CheckListValidator());
        }

        public CheckList()
        {

        }

        public CheckList(Guid id, string vehiclePlate)
        {
            Id = id;
            VehiclePlate = vehiclePlate;

            Validate(this, new CheckListValidator());
        }
    }
}
