using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using Gestran.VehicleControl.Domain.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class CheckList : BaseEntity
    {
        public CheckList()
        {
            CheckListItem = new HashSet<CheckListItem>();
        }

        public User User { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public CheckListStatus Status { get; set; }

        public virtual ICollection<CheckListItem>? CheckListItem { get; set; }

        [NotMapped]
        public bool DuplicatedPlateError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedPlateError = true;
            Validate(this, new CheckListValidator());
        }

        public CheckList(Guid id, string vehiclePlate)
        {
            Id = id;
            VehiclePlate = vehiclePlate;

            Validate(this, new CheckListValidator());
        }
    }
}
