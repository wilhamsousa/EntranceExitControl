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

        public Guid UserId { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public CheckListStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CheckListItem>? CheckListItem { get; set; }

        [NotMapped]
        public bool DuplicatedPlateError { get; private set; }
        [NotMapped]
        public bool UserNotFoundError { get; private set; }

        public void SetDuplicated()
        {
            DuplicatedPlateError = true;
            Validate(this, new CheckListValidator());
        }

        public void SetUserNotFound()
        {
            UserNotFoundError = true;
            Validate(this, new CheckListValidator());
        }

        public CheckList(Guid userId, string vehiclePlate, List<Item> items)
        {
            CheckListItem = new HashSet<CheckListItem>();
            UserId = userId;
            VehiclePlate = vehiclePlate;
            StartDateTime = DateTime.Now;
            Status = CheckListStatus.Started;
            Validate(this, new CheckListValidator());

            CheckListItem = new List<CheckListItem>();
            foreach (Item item in items)
                CheckListItem.Add(new CheckListItem(item.Id));
        }
    }
}
