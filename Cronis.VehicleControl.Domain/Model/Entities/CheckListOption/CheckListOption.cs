using Cronis.VehicleControl.Domain.Model.Base;
using Cronis.VehicleControl.Domain.Model.Validators;

namespace Cronis.VehicleControl.Domain.Model.Entities
{
    public class CheckListOption : BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }

        public virtual ICollection<CheckListItem>? CheckListItems { get; set; }

        public CheckListOption()
        {
            CheckListItems = new HashSet<CheckListItem>();
        }

        public CheckListOption(Guid id, string name, string note)
        {
            Id = id;
            Name = name;
            Note = note;

            Validate(this, new CheckListOptionValidator());
        }
    }

    public static class CheckListOptionMessage
    {
        public const string
            CHECKLISTPTION_ALREADY_EXISTS = "Já existe uma opção de checklist com este nome.";
    }
}
