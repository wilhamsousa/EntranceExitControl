using Gestran.VehicleControl.Domain.Model.Base;
using Gestran.VehicleControl.Domain.Model.Enums;

namespace Gestran.VehicleControl.Domain.Model.Entities
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

        public CheckList(Guid userId, string vehiclePlate, List<ItemCheckList> items)
        {
            CheckListItem = new HashSet<CheckListItem>();
            UserId = userId;
            VehiclePlate = vehiclePlate;
            StartDateTime = DateTime.Now;
            Status = CheckListStatus.Started;
            Validate(this, new CheckListValidator());

            CheckListItem = new List<CheckListItem>();
            foreach (ItemCheckList item in items)
                CheckListItem.Add(new CheckListItem(item.Id));
        }
    }

    public static class CheckListMessage
    {
        public const string 
            CHECKLIST_ALREADY_EXISTS = "Já existe um checklist para esta placa e outro usuário em aberto.",
            CHECKLIST_USER_NOTFOUND = "Usuário não encontrado.",
            CHECKLISTITEM_NOTFOUND = "Item de checklist não encontrado.";
    }
}
