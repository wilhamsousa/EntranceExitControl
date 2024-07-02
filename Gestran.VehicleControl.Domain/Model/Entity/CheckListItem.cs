using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class CheckListItem : BaseEntity
    {
        public Item Item { get; set; }
        public bool? Approved { get; set; }
        public DateTime DateTime { get; set; }

        public virtual CheckList CheckList { get; set; }

        [NotMapped]
        public bool DuplicatedPlateError { get; private set; }

        public CheckListItem()
        {

        }

        public CheckListItem(Guid id)
        {
            Id = id;
            Validate(this, new CheckListItemValidator());
        }
    }
}
