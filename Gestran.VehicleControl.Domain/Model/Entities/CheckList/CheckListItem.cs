using Gestran.VehicleControl.Domain.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestran.VehicleControl.Domain.Model.Entities
{
    public class CheckListItem : BaseEntity
    {
        public CheckListItem()
        {

        }

        public CheckListItem(
            Guid checkListId,
            Guid itemId,
            bool? approved,
            DateTime? dateTime
            )
        {
            CheckListId = checkListId;
            ItemId = itemId;
            Approved = approved;
            DateTime = dateTime;
        }

        public Guid CheckListId { get; set; }
        public Guid ItemId { get; set; }
        public bool? Approved { get; set; }
        public DateTime? DateTime { get; set; }

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
