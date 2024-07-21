using Gestran.VehicleControl.Domain.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entities
{
    public class CheckListItem : BaseEntity
    {
        public CheckListItem()
        {

        }

        public Guid CheckListId { get; private set; }
        public Guid ItemId { get; private set; }
        public bool? Approved { get; private set; }
        public DateTime? DateTime { get; private set; }

        public virtual CheckList CheckList { get; set; }
        public virtual ItemCheckList Item { get; set; }

        public void SetApproved(bool? approved) => Approved = approved;

        public CheckListItem(Guid itemId)
        {
            ItemId = itemId;
            Validate(this, new CheckListItemValidator());
        }
    }
}
