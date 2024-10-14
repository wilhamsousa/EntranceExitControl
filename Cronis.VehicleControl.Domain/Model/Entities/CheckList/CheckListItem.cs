using Cronis.VehicleControl.Domain.Model.Base;

namespace Cronis.VehicleControl.Domain.Model.Entities
{
    public class CheckListItem : BaseEntity
    {        
        public Guid CheckListId { get; set; }
        public Guid CheckListOptionId { get; set; }
        public bool? Approved { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual CheckList CheckList { get; set; }
        public virtual CheckListOption CheckListOption { get; set; }

        public void SetApproved(bool? approved) => Approved = approved;

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
            CheckListOptionId = itemId;
            Approved = approved;
            DateTime = dateTime;

            Validate(this, new CheckListItemValidator());
        }

        public CheckListItem(Guid itemId)
        {
            CheckListOptionId = itemId;
            Validate(this, new CheckListItemValidator());
        }
    }
}
