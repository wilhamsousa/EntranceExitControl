using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Model.Enums;

namespace Cronis.VehicleControl.Domain.Model.Entities
{
    public class CheckList : BaseEntity
    {        
        public Guid UserId { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public CheckListStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CheckListItem>? CheckListItems { get; set; }

        public CheckList()
        {
            CheckListItems = new HashSet<CheckListItem>();
        }

        public CheckList(Guid userId, string vehiclePlate, List<CheckListOption> items)
        {
            CheckListItems = new HashSet<CheckListItem>();
            UserId = userId;
            VehiclePlate = vehiclePlate;
            StartDateTime = DateTime.Now;
            Status = CheckListStatus.Started;
            Validate(this, new CheckListValidator());

            CheckListItems = new List<CheckListItem>();
            foreach (CheckListOption item in items)
                CheckListItems.Add(new CheckListItem(item.Id));
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
