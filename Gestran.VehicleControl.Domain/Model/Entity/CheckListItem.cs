using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Entity.Validator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entity
{
    public class CheckListItem : BaseEntity
    {
        public CheckListItem()
        {

        }

        public Guid CheckListId { get; set; }
        public Guid ItemId { get; set; }
        public bool? Approved { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual CheckList CheckList { get; set; }

        [NotMapped]
        public bool DuplicatedPlateError { get; private set; }

        public virtual Item Item { get; set; }
        
        public CheckListItem(Guid itemId)
        {
            ItemId = itemId;
            Validate(this, new CheckListItemValidator());
        }
    }
}
